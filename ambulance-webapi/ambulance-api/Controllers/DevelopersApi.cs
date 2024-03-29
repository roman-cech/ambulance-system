/*
 * Waiting List API
 *
 * Ambulance Waiting List managegement for Web In Cloud system
 *
 * OpenAPI spec version: 1.0.0-oas3
 * Contact: aa@bb.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using eu.incloud.ambulance.Attributes;

using Microsoft.AspNetCore.Authorization;
using eu.incloud.ambulance.Models;
using eu.incloud.ambulance.Services;
using System.Linq;

namespace eu.incloud.ambulance.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class DevelopersApiController : ControllerBase
    { 
        private readonly IDataRepository repository;
        
        ///
        public DevelopersApiController(IDataRepository repository){
            this.repository = repository;
        }
        
        /// <summary>
        /// Deletes specific entry
        /// </summary>
        /// <remarks>Use this method to delete the specific entry from the waiting list.</remarks>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <param name="entryId">pass the id of the particular entry in the waiting list</param>
        /// <response code="200">Item deleted</response>
        /// <response code="404">Ambulance or Entry with such ID does not exists</response>
        [HttpDelete]
        [Route("/api/waiting-list/{ambulanceId}/entry/{entryId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteWaitingListEntry")]
        public virtual IActionResult DeleteWaitingListEntry([FromRoute][Required]string ambulanceId, [FromRoute][Required]string entryId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            var entry = ambulance == null ? null
                : ambulance.WaitingList.FirstOrDefault(_ => _.Id.Equals(entryId));

            if( entry == null) { return new NotFoundResult(); }

            ambulance.WaitingList.Remove(entry);
            this.repository.UpsertAmbulanceData(ambulance);

            return new OkResult();
        }

        /// <summary>
        /// Provides waiting list of the ambulance
        /// </summary>
        /// <remarks>By using ambulanceId you can retrieve waiting list of that particular ambulance. </remarks>
        /// <param name="ambulanceId">pass the ambulanceId of the particular ambulance</param>
        /// <response code="200">array of the waiting list entries</response>
        /// <response code="404">Ambulance with such ID does not exists</response>
        [HttpGet]
        [Route("/api/waiting-list/{ambulanceId}")]
        [ValidateModelState]
        [SwaggerOperation("GetAmbulanceDetails")]
        [SwaggerResponse(statusCode: 200, type: typeof(Ambulance), description: "array of the waiting list entries")]
        public virtual ActionResult<Ambulance> GetAmbulanceDetails([FromRoute][Required]string ambulanceId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Ambulance));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            // CHANGE TO
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            if (ambulance == null) { return new NotFoundResult(); }
            else { return ambulance; }
        }

        /// <summary>
        /// Provides details about waiting list entry
        /// </summary>
        /// <remarks>By using ambulanceId and conditionCode you can get details of associated predefined condition.</remarks>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <param name="conditionCode">pass the code of the particular condition</param>
        /// <response code="200">value of the requested condition</response>
        /// <response code="404">Ambulance with such ID or Condition with such code does not exists</response>
        [HttpGet]
        [Route("/api/waiting-list/{ambulanceId}/condition/{conditionCode}")]
        [ValidateModelState]
        [SwaggerOperation("GetCondition")]
        [SwaggerResponse(statusCode: 200, type: typeof(Condition), description: "value of the requested condition")]
        public virtual ActionResult<Condition> GetCondition([FromRoute][Required]string ambulanceId, [FromRoute][Required]string conditionCode)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Condition));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            var condition = ambulance == null ? null
                : ambulance.PredefinedConditions.FirstOrDefault(_ => _.Code.Equals(conditionCode));

            if( condition == null) { return new NotFoundResult(); }
            else { return condition; }
        }

        /// <summary>
        /// Provides the list of conditions associated with ambulance
        /// </summary>
        /// <remarks>By using ambulanceId you get list of predefined conditions</remarks>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <response code="200">value of the predefined conditions</response>
        /// <response code="404">Ambulance with such ID does not exists</response>
        [HttpGet]
        [Route("/api/waiting-list/{ambulanceId}/condition")]
        [ValidateModelState]
        [SwaggerOperation("GetConditions")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<Condition>), description: "value of the predefined conditions")]
        public virtual ActionResult<List<Condition>> GetConditions([FromRoute][Required]string ambulanceId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<Condition>));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            if( ambulance == null) { return new NotFoundResult(); }

            return ambulance.PredefinedConditions;
        }

        /// <summary>
        /// Provides the ambulance waiting list
        /// </summary>
        /// <remarks>By using ambulanceId you get list of entries in ambulance witing list</remarks>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <response code="200">value of the waiting list entries</response>
        /// <response code="404">Ambulance with such ID does not exists</response>
        [HttpGet]
        [Route("/api/waiting-list/{ambulanceId}/entry")]
        [ValidateModelState]
        [SwaggerOperation("GetWaitingListEntries")]
        [SwaggerResponse(statusCode: 200, type: typeof(List<WaitingListEntry>), description: "value of the waiting list entries")]
        public virtual ActionResult<List<WaitingListEntry>> GetWaitingListEntries([FromRoute][Required]string ambulanceId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(List<WaitingListEntry>));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            if( ambulance == null) { return new NotFoundResult(); }

            return ambulance.WaitingList;
 
        }

        /// <summary>
        /// Provides details about waiting list entry
        /// </summary>
        /// <remarks>By using ambulanceId and entryId you can details of particular entry item ambulance.</remarks>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <param name="entryId">pass the id of the particular entry in the waiting list</param>
        /// <response code="200">value of the waiting list entries</response>
        /// <response code="404">Ambulance or Entry with such ID does not exists</response>
        [HttpGet]
        [Route("/api/waiting-list/{ambulanceId}/entry/{entryId}")]
        [ValidateModelState]
        [SwaggerOperation("GetWaitingListEntry")]
        [SwaggerResponse(statusCode: 200, type: typeof(WaitingListEntry), description: "value of the waiting list entries")]
        public virtual ActionResult<WaitingListEntry> GetWaitingListEntry([FromRoute][Required]string ambulanceId, [FromRoute][Required]string entryId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(WaitingListEntry));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            var entry = ambulance == null ? null
                : ambulance.WaitingList.FirstOrDefault(_ => _.Id.Equals(entryId));

            if( entry == null) { return new NotFoundResult(); }
            else { return entry; }
        }

        /// <summary>
        /// Saves new entry into waiting list
        /// </summary>
        /// <remarks>Use this method to store new entry into the waiting list.</remarks>
        /// <param name="body">Waiting list entry to store</param>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <response code="200">Value of the waiting list entry with re-computed estimated time of ambulance entry</response>
        /// <response code="400">Missing mandatory properties of input object.</response>
        /// <response code="404">Ambulance with such ID does not exists</response>
        [HttpPost]
        [Route("/api/waiting-list/{ambulanceId}/entry")]
        [ValidateModelState]
        [SwaggerOperation("StoreWaitingListEntry")]
        [SwaggerResponse(statusCode: 200, type: typeof(WaitingListEntry), description: "Value of the waiting list entry with re-computed estimated time of ambulance entry")]
        public virtual ActionResult<WaitingListEntry> StoreWaitingListEntry([FromBody]WaitingListEntry body, [FromRoute][Required]string ambulanceId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(WaitingListEntry));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            if( ambulance == null) { return new NotFoundResult(); }

            body.Id = Guid.NewGuid().ToString();
            ambulance.WaitingList.Add(body);
            this.repository.UpsertAmbulanceData(ambulance);

            return body;
        }

        /// <summary>
        /// Updates specific condition
        /// </summary>
        /// <remarks>Use this method to update content of the associated predefined condition.</remarks>
        /// <param name="body">Condition to update</param>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <param name="conditionCode">pass the code of the particular condition</param>
        /// <response code="200">Value updated</response>
        /// <response code="403">Value of the conditionCode and the code in data are mismatching. Details are provided in the response body.</response>
        /// <response code="404">Ambulance with such</response>
        [HttpPost]
        [Route("/api/waiting-list/{ambulanceId}/condition/{conditionCode}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateCondition")]
        public virtual IActionResult UpdateCondition([FromBody]Condition body, [FromRoute][Required]string ambulanceId, [FromRoute][Required]string conditionCode)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200);

            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
             if( ! conditionCode.Equals(body.Code))
            {
                return new BadRequestResult();
            }

            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            var condition = ambulance == null ? null
                : ambulance.PredefinedConditions.FirstOrDefault(
                    _ => _.Code.Equals(conditionCode));

            if( condition == null) { return new NotFoundResult(); }

            ambulance.PredefinedConditions.Remove(condition);
            ambulance.PredefinedConditions.Add(body);

            this.repository.UpsertAmbulanceData(ambulance);
            return new OkResult();
        }

        /// <summary>
        /// Updates specific entry
        /// </summary>
        /// <remarks>Use this method to update content of the waiting list entry.</remarks>
        /// <param name="body">Waiting list entry to update</param>
        /// <param name="ambulanceId">pass the id of the particular ambulance</param>
        /// <param name="entryId">pass the id of the particular entry in the waiting list</param>
        /// <response code="200">value of the waiting list entry with re-computed estimated time of ambulance entry</response>
        /// <response code="403">Value of the entryID and the data id is mismatching. Detail s are provided in the response body.</response>
        /// <response code="404">Ambulance or Entry with such ID does not exists</response>
        [HttpPost]
        [Route("/api/waiting-list/{ambulanceId}/entry/{entryId}")]
        [ValidateModelState]
        [SwaggerOperation("UpdateWaitingListEntry")]
        [SwaggerResponse(statusCode: 200, type: typeof(WaitingListEntry), description: "value of the waiting list entry with re-computed estimated time of ambulance entry")]
        public virtual ActionResult<WaitingListEntry> UpdateWaitingListEntry([FromBody]WaitingListEntry body, [FromRoute][Required]string ambulanceId, [FromRoute][Required]string entryId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(WaitingListEntry));

            //TODO: Uncomment the next line to return response 403 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(403);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            //CHANGE TO
            if( ! entryId.Equals(body.Id)) { return new BadRequestResult(); }

            var ambulance = this.repository.GetAmbulanceData(ambulanceId);
            var entry = ambulance == null ? null
                : ambulance.WaitingList.FirstOrDefault(_ => _.Id.Equals(entryId));

            if( entry == null) { return new NotFoundResult(); }

            ambulance.WaitingList.Remove(entry);
            ambulance.WaitingList.Add(body);

            this.repository.UpsertAmbulanceData(ambulance);
            return body;
        }
    }
}
