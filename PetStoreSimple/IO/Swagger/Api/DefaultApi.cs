using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns all pets from the system that the user has access to
        /// </remarks>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>List&lt;Pet&gt;</returns>
        List<Pet> FindPets (List<string> tags = null, int? limit = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns all pets from the system that the user has access to
        /// </remarks>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>ApiResponse of List&lt;Pet&gt;</returns>
        ApiResponse<List<Pet>> FindPetsWithHttpInfo (List<string> tags = null, int? limit = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns all pets from the system that the user has access to
        /// </remarks>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>Task of List&lt;Pet&gt;</returns>
        System.Threading.Tasks.Task<List<Pet>> FindPetsAsync (List<string> tags = null, int? limit = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns all pets from the system that the user has access to
        /// </remarks>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>Task of ApiResponse (List&lt;Pet&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Pet>>> FindPetsAsyncWithHttpInfo (List<string> tags = null, int? limit = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </remarks>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>Pet</returns>
        Pet AddPet (NewPet pet);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </remarks>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>ApiResponse of Pet</returns>
        ApiResponse<Pet> AddPetWithHttpInfo (NewPet pet);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </remarks>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>Task of Pet</returns>
        System.Threading.Tasks.Task<Pet> AddPetAsync (NewPet pet);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Creates a new pet in the store.  Duplicates are allowed
        /// </remarks>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>Task of ApiResponse (Pet)</returns>
        System.Threading.Tasks.Task<ApiResponse<Pet>> AddPetAsyncWithHttpInfo (NewPet pet);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a user based on a single ID, if the user does not have access to the pet
        /// </remarks>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>Pet</returns>
        Pet FindPetById (long? id);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a user based on a single ID, if the user does not have access to the pet
        /// </remarks>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>ApiResponse of Pet</returns>
        ApiResponse<Pet> FindPetByIdWithHttpInfo (long? id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a user based on a single ID, if the user does not have access to the pet
        /// </remarks>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>Task of Pet</returns>
        System.Threading.Tasks.Task<Pet> FindPetByIdAsync (long? id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Returns a user based on a single ID, if the user does not have access to the pet
        /// </remarks>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>Task of ApiResponse (Pet)</returns>
        System.Threading.Tasks.Task<ApiResponse<Pet>> FindPetByIdAsyncWithHttpInfo (long? id);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// deletes a single pet based on the ID supplied
        /// </remarks>
        /// <param name="id">ID of pet to delete</param>
        /// <returns></returns>
        void DeletePet (long? id);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// deletes a single pet based on the ID supplied
        /// </remarks>
        /// <param name="id">ID of pet to delete</param>
        /// <returns>ApiResponse of Object(void)</returns>
        ApiResponse<Object> DeletePetWithHttpInfo (long? id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// deletes a single pet based on the ID supplied
        /// </remarks>
        /// <param name="id">ID of pet to delete</param>
        /// <returns>Task of void</returns>
        System.Threading.Tasks.Task DeletePetAsync (long? id);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// deletes a single pet based on the ID supplied
        /// </remarks>
        /// <param name="id">ID of pet to delete</param>
        /// <returns>Task of ApiResponse</returns>
        System.Threading.Tasks.Task<ApiResponse<Object>> DeletePetAsyncWithHttpInfo (long? id);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default; 
            else
                this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }
    
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }
   
        
        /// <summary>
        ///  Returns all pets from the system that the user has access to
        /// </summary>
        /// <param name="tags">tags to filter by</param> 
        /// <param name="limit">maximum number of results to return</param> 
        /// <returns>List&lt;Pet&gt;</returns>
        public List<Pet> FindPets (List<string> tags = null, int? limit = null)
        {
             ApiResponse<List<Pet>> response = FindPetsWithHttpInfo(tags, limit);
             return response.Data;
        }

        /// <summary>
        ///  Returns all pets from the system that the user has access to
        /// </summary>
        /// <param name="tags">tags to filter by</param> 
        /// <param name="limit">maximum number of results to return</param> 
        /// <returns>ApiResponse of List&lt;Pet&gt;</returns>
        public ApiResponse< List<Pet> > FindPetsWithHttpInfo (List<string> tags = null, int? limit = null)
        {
            
    
            var path_ = "/pets";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json", "application/xml", "text/xml", "text/html"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (tags != null) queryParams.Add("tags", Configuration.ApiClient.ParameterToString(tags)); // query parameter
            if (limit != null) queryParams.Add("limit", Configuration.ApiClient.ParameterToString(limit)); // query parameter
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling FindPets: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling FindPets: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<List<Pet>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Pet>) Configuration.ApiClient.Deserialize(response, typeof(List<Pet>)));
            
        }
    
        /// <summary>
        ///  Returns all pets from the system that the user has access to
        /// </summary>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>Task of List&lt;Pet&gt;</returns>
        public async System.Threading.Tasks.Task<List<Pet>> FindPetsAsync (List<string> tags = null, int? limit = null)
        {
             ApiResponse<List<Pet>> response = await FindPetsAsyncWithHttpInfo(tags, limit);
             return response.Data;

        }

        /// <summary>
        ///  Returns all pets from the system that the user has access to
        /// </summary>
        /// <param name="tags">tags to filter by</param>
        /// <param name="limit">maximum number of results to return</param>
        /// <returns>Task of ApiResponse (List&lt;Pet&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Pet>>> FindPetsAsyncWithHttpInfo (List<string> tags = null, int? limit = null)
        {
            
    
            var path_ = "/pets";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json", "application/xml", "text/xml", "text/html"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (tags != null) queryParams.Add("tags", Configuration.ApiClient.ParameterToString(tags)); // query parameter
            if (limit != null) queryParams.Add("limit", Configuration.ApiClient.ParameterToString(limit)); // query parameter
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling FindPets: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling FindPets: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<List<Pet>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Pet>) Configuration.ApiClient.Deserialize(response, typeof(List<Pet>)));
            
        }
        
        /// <summary>
        ///  Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name="pet">Pet to add to the store</param> 
        /// <returns>Pet</returns>
        public Pet AddPet (NewPet pet)
        {
             ApiResponse<Pet> response = AddPetWithHttpInfo(pet);
             return response.Data;
        }

        /// <summary>
        ///  Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name="pet">Pet to add to the store</param> 
        /// <returns>ApiResponse of Pet</returns>
        public ApiResponse< Pet > AddPetWithHttpInfo (NewPet pet)
        {
            
            // verify the required parameter 'pet' is set
            if (pet == null) throw new ApiException(400, "Missing required parameter 'pet' when calling AddPet");
            
    
            var path_ = "/pets";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = Configuration.ApiClient.Serialize(pet); // http body (model) parameter
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling AddPet: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling AddPet: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<Pet>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Pet) Configuration.ApiClient.Deserialize(response, typeof(Pet)));
            
        }
    
        /// <summary>
        ///  Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>Task of Pet</returns>
        public async System.Threading.Tasks.Task<Pet> AddPetAsync (NewPet pet)
        {
             ApiResponse<Pet> response = await AddPetAsyncWithHttpInfo(pet);
             return response.Data;

        }

        /// <summary>
        ///  Creates a new pet in the store.  Duplicates are allowed
        /// </summary>
        /// <param name="pet">Pet to add to the store</param>
        /// <returns>Task of ApiResponse (Pet)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Pet>> AddPetAsyncWithHttpInfo (NewPet pet)
        {
            // verify the required parameter 'pet' is set
            if (pet == null) throw new ApiException(400, "Missing required parameter 'pet' when calling AddPet");
            
    
            var path_ = "/pets";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            
            
            postBody = Configuration.ApiClient.Serialize(pet); // http body (model) parameter
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling AddPet: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling AddPet: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<Pet>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Pet) Configuration.ApiClient.Deserialize(response, typeof(Pet)));
            
        }
        
        /// <summary>
        ///  Returns a user based on a single ID, if the user does not have access to the pet
        /// </summary>
        /// <param name="id">ID of pet to fetch</param> 
        /// <returns>Pet</returns>
        public Pet FindPetById (long? id)
        {
             ApiResponse<Pet> response = FindPetByIdWithHttpInfo(id);
             return response.Data;
        }

        /// <summary>
        ///  Returns a user based on a single ID, if the user does not have access to the pet
        /// </summary>
        /// <param name="id">ID of pet to fetch</param> 
        /// <returns>ApiResponse of Pet</returns>
        public ApiResponse< Pet > FindPetByIdWithHttpInfo (long? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling FindPetById");
            
    
            var path_ = "/pets/{id}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json", "application/xml", "text/xml", "text/html"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (id != null) pathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling FindPetById: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling FindPetById: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<Pet>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Pet) Configuration.ApiClient.Deserialize(response, typeof(Pet)));
            
        }
    
        /// <summary>
        ///  Returns a user based on a single ID, if the user does not have access to the pet
        /// </summary>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>Task of Pet</returns>
        public async System.Threading.Tasks.Task<Pet> FindPetByIdAsync (long? id)
        {
             ApiResponse<Pet> response = await FindPetByIdAsyncWithHttpInfo(id);
             return response.Data;

        }

        /// <summary>
        ///  Returns a user based on a single ID, if the user does not have access to the pet
        /// </summary>
        /// <param name="id">ID of pet to fetch</param>
        /// <returns>Task of ApiResponse (Pet)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Pet>> FindPetByIdAsyncWithHttpInfo (long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling FindPetById");
            
    
            var path_ = "/pets/{id}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json", "application/xml", "text/xml", "text/html"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (id != null) pathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, Method.GET, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling FindPetById: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling FindPetById: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<Pet>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Pet) Configuration.ApiClient.Deserialize(response, typeof(Pet)));
            
        }
        
        /// <summary>
        ///  deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name="id">ID of pet to delete</param> 
        /// <returns></returns>
        public void DeletePet (long? id)
        {
             DeletePetWithHttpInfo(id);
        }

        /// <summary>
        ///  deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name="id">ID of pet to delete</param> 
        /// <returns>ApiResponse of Object(void)</returns>
        public ApiResponse<Object> DeletePetWithHttpInfo (long? id)
        {
            
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling DeletePet");
            
    
            var path_ = "/pets/{id}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (id != null) pathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeletePet: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeletePet: " + response.ErrorMessage, response.ErrorMessage);
    
            
            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
    
        /// <summary>
        ///  deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name="id">ID of pet to delete</param>
        /// <returns>Task of void</returns>
        public async System.Threading.Tasks.Task DeletePetAsync (long? id)
        {
             await DeletePetAsyncWithHttpInfo(id);

        }

        /// <summary>
        ///  deletes a single pet based on the ID supplied
        /// </summary>
        /// <param name="id">ID of pet to delete</param>
        /// <returns>Task of ApiResponse</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Object>> DeletePetAsyncWithHttpInfo (long? id)
        {
            // verify the required parameter 'id' is set
            if (id == null) throw new ApiException(400, "Missing required parameter 'id' when calling DeletePet");
            
    
            var path_ = "/pets/{id}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            // to determine the Accept header
            String[] http_header_accepts = new String[] {
                "application/json"
            };
            String http_header_accept = Configuration.ApiClient.SelectHeaderAccept(http_header_accepts);
            if (http_header_accept != null)
                headerParams.Add("Accept", Configuration.ApiClient.SelectHeaderAccept(http_header_accepts));

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (id != null) pathParams.Add("id", Configuration.ApiClient.ParameterToString(id)); // path parameter
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, pathParams);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeletePet: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeletePet: " + response.ErrorMessage, response.ErrorMessage);

            
            return new ApiResponse<Object>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                null);
        }
        
    }
    
}
