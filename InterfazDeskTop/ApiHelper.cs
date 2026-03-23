﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace InterfazDeskTop
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            // CORREGIDO: Usar HTTP en lugar de HTTPS, y el puerto correcto 5198
            ApiClient.BaseAddress = new Uri("http://localhost:5000/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<T> PostAsync<T>(string url, object data)
        {
            try
            {
                var json = new JavaScriptSerializer().Serialize(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await ApiClient.PostAsync(url, content))
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return new JavaScriptSerializer().Deserialize<T>(jsonResponse);
                    }
                    else
                    {
                        throw new Exception($"Error en la API ({response.StatusCode}): {jsonResponse}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}\nURL: {ApiClient.BaseAddress}{url}");
            }
        }

        public static async Task<T> GetAsync<T>(string url)
        {
            try
            {
                using (HttpResponseMessage response = await ApiClient.GetAsync(url))
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return new JavaScriptSerializer().Deserialize<T>(jsonResponse);
                    }
                    else
                    {
                        throw new Exception($"Error en la API ({response.StatusCode}): {jsonResponse}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error de conexión: {ex.Message}\nURL: {ApiClient.BaseAddress}{url}");
            }
        }
    }
}