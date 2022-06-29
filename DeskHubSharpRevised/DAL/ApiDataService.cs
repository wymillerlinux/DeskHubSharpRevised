using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DeskHubSharpRevised.Data;
using DeskHubSharpRevised.Models;
using Newtonsoft.Json;
using RestSharp;

namespace DeskHubSharpRevised.DAL;

public class ApiDataService
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
                var client = new RestClient(_apiEndpoint);
                RestRequest requestRepo = new RestRequest($"users/{_query}/repos", Method.Get);

                var response = client.Execute(requestRepo);
                var x = response.Content;
                var deserialized = JsonConvert.DeserializeObject<ObservableCollection<RepoDetail>>(x);

                if (deserialized.Count == 0)
                {
                    throw new Exception();
                }
                else
                {
                    RequestList.repoDetail = deserialized;
                }
            }
            catch (Exception)
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
                var client = new RestClient(_apiEndpoint);

                RestRequest requestUser = new RestRequest($"users/{_query}", Method.Get);

                var response = client.Execute(requestUser);
                string x = response.Content;
                var deserailized = JsonConvert.DeserializeObject<User>(x);

                if (deserailized == null)
                {
                    throw new Exception();
                }
                else
                {
                    RequestList.userDetail = deserailized;
                }

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
                var client = new RestClient(_apiEndpoint);

                RestRequest requestUser = new RestRequest($"/repos/{RequestList.userDetail.login}/{_query}/branches", Method.Get);

                var response = client.Execute(requestUser);
                string x = response.Content;
                var deserailized = JsonConvert.DeserializeObject<ObservableCollection<Branch>>(x);

                RequestList.branchDetail = deserailized;
            }
            catch (NullReferenceException)
            {
                ErrorWindow err = new ErrorWindow();
                err.txtblk_error.Text = "We couldn't gather user data. Please try again.";
            }
        }
}