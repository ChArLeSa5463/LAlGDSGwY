// 代码生成时间: 2025-10-25 17:25:30
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonFormattingApp
{
    public class JsonDataFormatter
    {
        /// <summary>
        /// Converts a JSON string from one format to another.
        /// </summary>
        /// <typeparam name="T">The type of the object to convert to.</typeparam>
        /// <param name="jsonString">The JSON string to convert.</param>
        /// <param name="options">The JsonSerializerOptions to use for deserialization.</param>
        /// <returns>The converted object or null if conversion fails.</returns>
        public T ConvertJson<T>(string jsonString, JsonSerializerOptions options = null)
        where T : class
        {
            try
            {
                // Deserialize the JSON string to the desired object type.
                var result = JsonSerializer.Deserialize<T>(jsonString, options);
                return result;
            }
            catch (JsonException ex)
            {
                // Handle JSON parsing errors.
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions.
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Converts an object to a JSON string.
        /// </summary>
        /// <param name="obj">The object to convert.</param>
        /// <param name="options">The JsonSerializerOptions to use for serialization.</param>
        /// <returns>The JSON string representation of the object or null if serialization fails.</returns>
        public string ConvertToJson(object obj, JsonSerializerOptions options = null)
        {
            try
            {
                // Serialize the object to a JSON string.
                return JsonSerializer.Serialize(obj, typeof(T), options);
            }
            catch (JsonException ex)
            {
                // Handle JSON serialization errors.
                Console.WriteLine($"Error serializing to JSON: {ex.Message}");
                return null;
            }
            catch (Exception ex)
            {
                // Handle other possible exceptions.
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}
