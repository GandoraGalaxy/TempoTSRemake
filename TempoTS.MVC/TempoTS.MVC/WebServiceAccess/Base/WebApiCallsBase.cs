﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TempoTS.MVC.Configuration;

namespace TempoTS.MVC.WebServiceAccess.Base
{
    public abstract class WebApiCallsBase
    {
        protected readonly string ServiceAddress;
        protected readonly string DepartmentUri;
        protected readonly string PayrollUri;
        protected readonly string TimeClockUri;
        protected readonly string UserUri;

        protected WebApiCallsBase(IWebServiceLocator settings)
        {
            ServiceAddress = settings.ServiceAddress;
            DepartmentUri = $"{ServiceAddress}api/Department/";
            PayrollUri = $"{ServiceAddress}api/Payroll/";
            TimeClockUri = $"{ServiceAddress}api/TimeClock/";
            UserUri = $"{ServiceAddress}api/User/";
        }

        internal async Task<string> GetJsonFromGetResponseAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync(uri);
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"The Call to {uri} failed.  Status code: {response.StatusCode}");
                    }
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

        }
        internal async Task<T> GetItemAsync<T>(string uri)
            where T : class, new()
        {
            try
            {
                var json = await GetJsonFromGetResponseAsync(uri);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw;
            }
        }
        internal async Task<IList<T>> GetItemListAsync<T>(string uri)
            where T : class, new()
        {
            try
            {
                return JsonConvert.DeserializeObject<IList<T>>(await GetJsonFromGetResponseAsync(uri));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        protected static async Task<string> ExecuteRequestAndProcessResponse(
            string uri, Task<HttpResponseMessage> task)
        {
            try
            {
                var response = await task;
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"The Call to {uri} failed.  Status code: {response.StatusCode}");
                }
                //return response.Headers.Location.AbsoluteUri;
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw;
            }
        }

        protected StringContent CreateStringContent(string json)
        {
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        protected async Task<string> SubmitPostRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                var task = client.PostAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }

        protected async Task<string> SubmitPutRequestAsync(string uri, string json)
        {
            using (var client = new HttpClient())
            {
                //var requestMessage = new HttpRequestMessage(HttpMethod.Put,uri);
                //requestMessage.Content = CreateStringContent(json);
                //var response = await client.SendAsync(requestMessage);
                Task<HttpResponseMessage> task = client.PutAsync(uri, CreateStringContent(json));
                return await ExecuteRequestAndProcessResponse(uri, task);
            }
        }
        protected async Task SubmitDeleteRequestAsync(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Task<HttpResponseMessage> deleteAsync = client.DeleteAsync(uri);
                    var response = await deleteAsync;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
