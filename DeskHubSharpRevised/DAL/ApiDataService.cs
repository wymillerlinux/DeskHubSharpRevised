using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DeskHubSharpRevised.Data;
using DeskHubSharpRevised.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DeskHubSharpRevised.DAL;

public class ApiDataService : IDataService
{
    private string _apiEndpoint;
        private string _query;

        public List<RepoDetail> RepoDetail { get; set; }

        public ApiDataService(string query)
        {
            _query = query;
            _apiEndpoint = DataConfig.dataConfString;
        }

        //public Request(string query, Object function)
        //{
        //    _query = query;
        //} 
        /// <summary>
        /// Calls API for repo and basic user data
        /// </summary>
        /// <returns></returns>
        public void SearchRequest()
        {
            try
            {
                RestClient client = new RestClient(_apiEndpoint);
                RestRequest requestRepo = new RestRequest($"users/{_query}/repos", Method.Get);

                string? response = client.Execute(requestRepo).Content;
                RequestList.repoDetail = JsonConvert.DeserializeObject<ObservableCollection<RepoDetail>>(response);
            }
            catch (NullReferenceException)
            {
                ErrorWindow err = new ErrorWindow();
                err.txtblk_error.Text = "We couldn't gather repository data. Please try again";
            }
        }


        /// <summary>
        /// Calls API for detailed user data
        /// </summary>
        public void UserRequest()
        {
            try
            {
                RestClient client = new RestClient(_apiEndpoint);
                RestRequest requestUser = new RestRequest($"users/{_query}", Method.Get);

                string? response = client.Execute(requestUser).Content;
                RequestList.userDetail  = JsonConvert.DeserializeObject<User>(response);
            }
            catch (NullReferenceException)
            {
                ErrorWindow err = new ErrorWindow();
                err.txtblk_error.Text = "We couldn't gather user data. Please try again.";
            }

        }

        /// <summary>
        /// Calls API for detailed branch data
        /// </summary>
        public void BranchRequest()
        {
            try
            {
                RestClient client = new RestClient(_apiEndpoint);
                RestRequest requestUser = new RestRequest($"/repos/{RequestList.userDetail.login}/{_query}/branches", Method.Get);

                string? response = client.Execute(requestUser).Content;
                RequestList.branchDetail = JsonConvert.DeserializeObject<ObservableCollection<Branch>>(response);
            }
            catch (NullReferenceException)
            {
                ErrorWindow err = new ErrorWindow();
                err.txtblk_error.Text = "We couldn't gather user data. Please try again.";
            }
        }
}