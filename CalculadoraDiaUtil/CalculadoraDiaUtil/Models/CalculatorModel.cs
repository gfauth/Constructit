using System;

namespace CalculadoraDiaUtil.Models
{
    public class CalculatorModel
    {
        private string _result;

        /// <summary>
        /// Construtor da classe CalculatorModel.
        /// </summary>
        /// <param name="data">(DateTime) Parâmetro necessário para realizar a conta.</param>
        public CalculatorModel(DateTime data)
        {
            int mes = data.Month;
            int ano = data.Year;

            // Gerando uma data com o primeiro dia do mês recebido na data de parâmetro.
            DateTime firstDay = new DateTime(ano, mes, 1);

            // Verifica o dia da semana é o primeiro dia doi mês, e a partir disso, realiza a verificação do quinto dia útil.
            switch (firstDay.DayOfWeek.ToString())
            {
                case "Sunday":
                    firstDay = firstDay.AddDays(5);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Monday":
                    firstDay = firstDay.AddDays(4);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Tuesday":
                    firstDay = firstDay.AddDays(6);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Wednesday":
                    firstDay = firstDay.AddDays(6);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Thursday":
                    firstDay = firstDay.AddDays(6);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Friday":
                    firstDay = firstDay.AddDays(6);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
                case "Saturday":
                    firstDay = firstDay.AddDays(6);
                    _result = string.Format("{0}, {1}", firstDay.Day, Translate(firstDay.DayOfWeek.ToString()));
                    break;
            }
            if (firstDay.DayOfWeek.Equals(""))
            {
                firstDay.AddDays(4);
                _result = firstDay.DayOfWeek.ToString();
            }
        }
        /// <summary>
        /// GetResult. Realiza a busca do valor atribuido ao resultado da verificação da data.
        /// </summary>
        /// <returns>(string) informativo do resultado do cálculo.</returns>
        public string GetResult()
        {
            return string.Format(_result);
        }

        /// <summary>
        /// Translate. Realiza a tradução do nome em inglês pra português.
        /// </summary>
        /// <param name="name">(string) Nome do dia da semana a ser traduzido.</param>
        /// <returns>(string) Nome traduzido.</returns>
        private string Translate(string name)
        {
            switch (name)
            {
                case "Sunday":
                    return "Domingo";
                case "Monday":
                    return "Segunda-Feira";
                case "Tuesday":
                    return "Terça-Feira";
                case "Wednesday":
                    return "Quarta-Feira";
                case "Thursday":
                    return "Quinta-Feira";
                case "Friday":
                    return "Sexta-Feira";
                case "Saturday":
                    return "Domingo";
                default:
                    return null;
            }
        }
    }
}
