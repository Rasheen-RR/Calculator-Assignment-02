using System;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;


namespace CalculatorLibrary
{
    public class Calculator
    {

        JsonWriter writer;
        StreamWriter logFile;

        public Calculator()
        {
            try
            {
                logFile = File.CreateText("calculator.log");

                Trace.Listeners.Add(new TextWriterTraceListener(logFile));
                Trace.AutoFlush = true;
                Trace.WriteLine("Starting Calculator Log");
                Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));

                StreamWriter jsonLogFile = File.CreateText("calculatorlog.json");
                jsonLogFile.AutoFlush = true;
                writer = new JsonTextWriter(jsonLogFile);
                writer.Formatting = Formatting.Indented;
                writer.WriteStartObject();
                writer.WritePropertyName("Operations");
                writer.WriteStartArray();
            }
            catch (Exception ex)
            {
                JsonWriter errorWriter;


                StreamWriter jsonErrorFile = File.CreateText("errorlog.json");
                jsonErrorFile.AutoFlush = true;
                errorWriter = new JsonTextWriter(jsonErrorFile);
                errorWriter.Formatting = Formatting.Indented;
                errorWriter.WriteStartObject();
                errorWriter.WritePropertyName("Error");
                errorWriter.WriteStartArray();

                writer.WriteStartObject();
                writer.WritePropertyName("Error");
                writer.WriteValue(ex.Message);

                errorWriter.WriteEndArray();
                errorWriter.WriteEndObject();
                errorWriter.Close();
            }
        }

        public  Result DoOperation(double num1, double num2, string op)
        {
            Result result = new Result
            {
                result = double.NaN,
                op = ""
            };

            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            switch (op.ToLower())
            {
                case "a":
                    result.result = num1 + num2;
                    result.op = "+";
                    logAction("Addition", num1, num2, result.result, "+");
                    break;
                case "s":
                    result.result = num1 - num2;
                    result.op = "-";
                    logAction("Substract", num1, num2, result.result, "-");
                    break;
                case "m":
                    result.result = num1 * num2;
                    result.op = "*";
                    logAction("Multiply", num1, num2, result.result, "x");
                    break;
                case "d":
                    if (num2 != 0)
                    {
                        result.result = num1 / num2;
                        result.op = "/";
                        logAction("Divide", num1, num2, result.result, "/");
                    }
                    else
                    {
                        result.result = double.PositiveInfinity;
                    }

                    break;
                case "r":

                    if (num2 != 0)
                    {
                        result.result = num1 % num2;
                        result.op = "%";
                        logAction("Modulo", num1, num2, result.result, "%");
                    }
                    break;
                default:
                    break;
            }

            if(!Double.IsNaN(result.result) && !double.IsInfinity(result.result))
            {
                Console.WriteLine("ass");
                writer.WritePropertyName("Result");
                writer.WriteValue(result.result);
                writer.WriteEndObject();
            }
            
            return result;
        }


        private void logAction(String operation, double num1, double num2, double result, string operand)
        {
            writer.WriteValue(operation);

            Trace.WriteLine(String.Format("{0} function used by the user! Equation found below", operation));
            Trace.WriteLine(String.Format("{0} {1} {2} = {3}", num1,operand, num2, result));
        }

        public void Finish()
        {

            logFile.Close();

            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }

    }
}
