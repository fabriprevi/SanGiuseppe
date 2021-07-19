using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SanGiuseppe.Models;
using SanGiuseppe.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel;
using SanGiuseppe.Controllers;
using System.Reflection;

namespace SanGiuseppe.Services
{
    public class Functions : Controller
    {

        private readonly SanGiuseppeContext _context;

        public Functions(SanGiuseppeContext context)
        {
            _context = context;
        }


        public IQueryable ListaCampiDaModello<T>(IQueryable righe)
        {

            var listaCampi = typeof(T)
                .GetProperties()
                .Select(prop => new FieldType
                {
                    FieldName = prop.Name.ToLower(),

                });
            return (IQueryable)listaCampi;

        }
        public List<Filtri> ListaCampi(string nometabella)
        {

            var listacampi = _context.Filtri.Select(a => new Filtri
            {

                Descrizione = a.Descrizione,
                Campo = a.Campo,
                Tabella = a.Tabella
            })
                .Where(a => a.Tabella == nometabella)
                .OrderBy(a => a.Descrizione).ToList();

            return listacampi;

        }


        public readonly static string[] ArithmeticOperations = { "<", ">", "<=", ">=", "=" };

        public object Convert(Type type, string value)
        {
            try
            {
                if ((type == typeof(DateTime) || type == typeof(DateTime?)))
                {
                    //var cultureInfo = new CultureInfo("it-IT");
                    //var dateTime = DateTime.Parse(value, cultureInfo);
                    var dateTime = DateTime.Parse(value);
                    return dateTime;
                }
                //else if ((type == typeof(int) || type == typeof(int?)))
                //{

                //}
                //else if (type == typeof(string))
                //{

                //}
                //else if (type == typeof(bool) || type == typeof(bool?))
                //{

                //}

                var converter = TypeDescriptor.GetConverter(type);
                var result = converter.ConvertFrom(value);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public string CleanValue(FiltriRequest.ColumnRequest column) => column.Search.Value?.Substring(1, column.Search.Value.Length - 2);

        public IQueryable Filtri<T>(IQueryable righe, FiltriRequest request)
        {

            var types = typeof(T)
                  .GetProperties()
                  .Select(prop => new FieldType
                  {
                      FieldName = prop.Name.ToLower(),
                      Type = prop.PropertyType
                  });

            // Search Value from (Search box)  
            var columnNameOperatorValuesString = request.Search.Value;
            if (!string.IsNullOrEmpty(columnNameOperatorValuesString))
            {
                var columnNameOperatorValuesList = columnNameOperatorValuesString.Split(',');
                foreach (string columnNameOperatorValue in columnNameOperatorValuesList)
                {

                    var keyOperatorValueSplitted = columnNameOperatorValue.Split("|");
                    var columnName = keyOperatorValueSplitted[0].ToLower();
                    var operatore = keyOperatorValueSplitted[1];
                    var value = keyOperatorValueSplitted[2];

                    if (string.IsNullOrEmpty(value))
                    {
                        continue;
                    }

                    var columnTypeValue = types.Where(t => t.FieldName.Equals(columnName))
                      .Select(t => new
                      {
                          ConvertedValue = Convert(t.Type, value),
                          Type = t.Type
                      })
                      .Where(x => x.ConvertedValue != null)
                      .FirstOrDefault();

                    try
                    {
                        if (columnTypeValue != null)
                        {
                            if ((columnTypeValue.Type == typeof(DateTime) || columnTypeValue.Type == typeof(DateTime?)) && Functions.ArithmeticOperations.Any(x => x == operatore))
                            {
                                var date = (DateTime)columnTypeValue.ConvertedValue;
                                righe = righe.Where($"{columnName} {operatore} @0", date);
                                //pubblicazioniDigitaliRows = pubblicazioniDigitaliRows.Where(x => x.DataInserimento < date);
                            }
                            else if ((columnTypeValue.Type == typeof(int) || columnTypeValue.Type == typeof(int?)) && Functions.ArithmeticOperations.Any(x => x == operatore))
                            {
                                var integer = (int)columnTypeValue.ConvertedValue;
                                righe = righe.Where($"{columnName} {operatore} {integer}");
                            }
                            else if ((columnTypeValue.Type == typeof(short) || columnTypeValue.Type == typeof(short?)) && Functions.ArithmeticOperations.Any(x => x == operatore))
                            {
                                var integer = (short)columnTypeValue.ConvertedValue;
                                righe = righe.Where($"{columnName} {operatore} {integer}");
                            }
                            else if (columnTypeValue.Type == typeof(string))
                            {
                                if (operatore.Equals("="))
                                {
                                    righe = righe.Where($"{columnName}.Equals(@0)", columnTypeValue.ConvertedValue);
                                }
                                else if (operatore.Equals("Contiene"))
                                {
                                    righe = righe.Where($"{columnName}.Contains(@0)", columnTypeValue.ConvertedValue);
                                }
                            }
                            else if (columnTypeValue.Type == typeof(bool) || columnTypeValue.Type == typeof(bool?))
                            {
                                var boolean = (bool)columnTypeValue.ConvertedValue;
                                if (operatore.Equals("="))
                                {
                                    righe = righe.Where($"{columnName} {operatore} {boolean}");



                                }
                            }
                        }

                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }
            }

            // filter by column
            foreach (var column in request.Columns)
            {
                if (!string.IsNullOrEmpty(column.Search.Value))
                {
                    //var cleanedValue = _Functions.CleanValue(column);
                    righe = righe.Where($"{column.Name} = @0", column.Search.Value);
                }

            }






            return righe;
        }

    }



    class FieldType
    {
        public string FieldName { get; set; }
        public Type Type { get; set; }
    }

}
