using FveyeWebAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace test
{
    public class GetApi
    {
        string url = "https://iriskenkou-api.airisutech.com/api/";
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response;
        string responseBody = "";


        /***********Companys**********/
        public async Task<List<Company>> GetAllCompanys()
        {
            response = await httpClient.GetAsync(url + "company").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Company> Name = JsonConvert.DeserializeObject<List<Company>>(responseBody);
            return Name;
        }

        /*********Customer************/
        public async Task<List<Customer>> GetAllCustomers(string CompID)
        {
            response = await httpClient.GetAsync(url + "customer" + "/" + CompID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Customer> Customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);
            return Customers;
        }

        public async Task<List<Customer>> GetCustomerByID(string CompID, string ID)
        {
            response = await httpClient.GetAsync(url + "customer" + "/" + CompID + "/" + ID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Customer> Customers = JsonConvert.DeserializeObject<List<Customer>>(responseBody);
            return Customers;
        }

        /************Check************/
        public async Task<List<Check>> GetCustCheck(string compID, string custID)
        {
            response = await httpClient.GetAsync(url + "check/" + compID + "/" + custID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Check> Check = JsonConvert.DeserializeObject<List<Check>>(responseBody);
            return Check;
        }
        public async Task<List<Check_Part_Score>> GetCustCheckScoreByID(string compID, string custID, int ID)
        {
            response = await httpClient.GetAsync(url + "check_score" + "/" + compID + "/" + custID + "/" + ID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Check_Part_Score> Check_Part_Score = JsonConvert.DeserializeObject<List<Check_Part_Score>>(responseBody);
            return Check_Part_Score;
        }
        public async Task<List<Check_Count>> GetCheckCountYear()
        {
            response = await httpClient.GetAsync(url + "check_count_year").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Check_Count> Check_Counts = JsonConvert.DeserializeObject<List<Check_Count>>(responseBody);
            return Check_Counts;
        }

        public async Task<List<Check_Count>> GetCheckCountMonth()
        {
            response = await httpClient.GetAsync(url + "check_count_month").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Check_Count> Check_Counts = JsonConvert.DeserializeObject<List<Check_Count>>(responseBody);
            return Check_Counts;
        }

        public async Task<List<Check_Count>> GetCheckCountWeek()
        {
            response = await httpClient.GetAsync(url + "check_count_week").ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            List<Check_Count> Check_Counts = JsonConvert.DeserializeObject<List<Check_Count>>(responseBody);
            return Check_Counts;
        }
        public async Task<Check> GetLastCheck(string CompID, string CustID)
        {
            response = await httpClient.GetAsync(url + "check_last/" + CompID + "/" + CustID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            Check Check = JsonConvert.DeserializeObject<Check>(responseBody);
            return Check;
        }

        /************Analysis************/

        public async Task<AnalysisData_Iris_Post> GetAnalysis(string CompID, string CustID, int CheckID)
        {
            response = await httpClient.GetAsync(url + "analysisdata/" + CompID + "/" + CustID + "/" + CheckID).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
                return null;
            responseBody = await response.Content.ReadAsStringAsync();
            AnalysisData_Iris_Post AnalysisData_Iris_Post = JsonConvert.DeserializeObject<AnalysisData_Iris_Post>(responseBody);
            return AnalysisData_Iris_Post;
        }

    }

}