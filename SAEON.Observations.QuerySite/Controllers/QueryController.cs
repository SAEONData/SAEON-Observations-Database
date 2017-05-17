﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SAEON.Observations.Core;
using SAEON.Observations.Core.Entities;
using SAEON.Observations.QuerySite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SAEON.Observations.QuerySite.Controllers
{
    [Authorize]
    public class QueryController : BaseWebApiController
    {

        //public QueryController() : base()
        //{
        //    using (Logging.MethodCall(this.GetType()))
        //    {
        //    }
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    using (Logging.MethodCall(this.GetType()))
        //    {
        //        base.Dispose(disposing);
        //    }
        //}

        private QueryModel SessionModel
        {
            get
            {
                return GetSessionModel<QueryModel>();
            }
            set
            {
                SetSessionModel<QueryModel>(value);
            }
        }

        private async Task<QueryModel> CreateSessionModel()
        {
            var sessionModel = new QueryModel()
            {
                Locations = await GetLocationsList(),
                Features = await GetFeaturesList(),
                UserQueries = await GetUserQueriesList()
            };
            LoadMapPoints(sessionModel);
            return sessionModel;
        }

        // GET: Query
        public async Task<ActionResult> Index()
        {
            using (Logging.MethodCall(GetType()))
            {
                var sessionModel = await CreateSessionModel();
                SessionModel = sessionModel;
                //Logging.Verbose("Model: {@model}", model);
                return View(sessionModel);
            }
        }

        public async Task<ActionResult> MapTest()
        {
            using (Logging.MethodCall(GetType()))
            {
                var sessionModel = await CreateSessionModel();
                SessionModel = sessionModel;
                //Logging.Verbose("Model: {@model}", model);
                return View(sessionModel);
            }
        }

        #region GeoJson
        //public async Task<ContentResult> GetSelectedLocations()
        //{
        //    var model = SessionModel;
        //    if (model.Locations == null)
        //    {
        //        model.Locations = await GetLocations();
        //    }
        //    SessionModel = model;
        //    var locations = model.SelectedLocations.Where(i => i.Latitude.HasValue && i.Longitude.HasValue);
        //    List<geoF.Feature> features = new List<geoF.Feature>();
        //    foreach (var loc in locations)
        //    {
        //        var point = new geoG.Point(new geoG.GeographicPosition(loc.Latitude.Value, loc.Longitude.Value, loc.Elevation));
        //        var featureProperties = new Dictionary<string, object> { };
        //        featureProperties.Add("Name", loc.Name);
        //        featureProperties.Add("Url", loc.Url);
        //        features.Add(new geoF.Feature(point, featureProperties));
        //    }
        //    return Content(JsonConvert.SerializeObject(new geoF.FeatureCollection(features), new StringEnumConverter()), "application/json");
        //}

        //public async Task<ContentResult> GetUnselectedLocations()
        //{
        //    var model = SessionModel;
        //    if (model.Locations == null)
        //    {
        //        model.Locations = await GetLocations();
        //    }
        //    SessionModel = model;
        //    var locations = model.Locations
        //        .Where(i => i.Latitude.HasValue && i.Longitude.HasValue)
        //        .Except(model.SelectedLocations.Where(i => i.Latitude.HasValue && i.Longitude.HasValue));
        //    List<geoF.Feature> features = new List<geoF.Feature>();
        //    foreach (var loc in locations)
        //    {
        //        var point = new geoG.Point(new geoG.GeographicPosition(loc.Latitude.Value, loc.Longitude.Value, loc.Elevation));
        //        var featureProperties = new Dictionary<string, object> { };
        //        featureProperties.Add("Name", loc.Name);
        //        featureProperties.Add("Url", loc.Url);
        //        features.Add(new geoF.Feature(point, featureProperties));
        //    }
        //    var col = new geoF.FeatureCollection(features);
        //    var json = JsonConvert.SerializeObject(new geoF.FeatureCollection(features), new StringEnumConverter());
        //    Logging.Verbose("Json: {json}", json);
        //    return Content(json, "application/json");
        //}

        private void LoadMapPoints(QueryModel model)
        {
            model.MapPoints.Clear();
            var u = model.Locations
                .Where(i => i.Latitude.HasValue && i.Longitude.HasValue)
                .Except(model.SelectedLocations.Where(i => i.Latitude.HasValue && i.Longitude.HasValue))
                .Select(i => new MapPoint { Title = i.Name, Url = i.Url, Latitude = i.Latitude.Value, Longitude = i.Longitude.Value, Elevation = i.Elevation });
            model.MapPoints.AddRange(u);
            var s = model.SelectedLocations
                .Where(i => i.Latitude.HasValue && i.Longitude.HasValue)
                .Select(i => new MapPoint { Title = i.Name, Url = i.Url, Latitude = i.Latitude.Value, Longitude = i.Longitude.Value, Elevation = i.Elevation, IsSelected = true });
            model.MapPoints.AddRange(s);
        }

        [HttpGet]
        public JsonResult GetMapPoints()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    Logging.Verbose("MapPoints: {count}", sessionModel.MapPoints.Count);
                    //Logging.Verbose("MapPoints: {count} {@list}", model.MapPoints.Count, model.MapPoints);
                    var result = Json(sessionModel.MapPoints, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        #endregion

        #region Locations
        private async Task<List<Location>> GetLocationsList()
        {
            return (await GetList<Location>("Locations")).ToList();
        }

        [HttpGet]
        public JsonResult GetLocations()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    var result = Json(sessionModel.Locations, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetLocationsHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("LocationsHtml", SessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetSelectedLocationsHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("SelectedLocationsHtml", SessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpPost]
        public PartialViewResult UpdateSelectedLocations(List<string> locations)
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    Logging.Verbose("SelectedLocations: {locations}", locations);
                    var sessionModel = SessionModel;
                    var selectedLocations = new List<Location>();
                    if (locations != null)
                    {
                        // Set IsCheck for all
                        foreach (var location in sessionModel.Locations.Where(i => locations.Contains(i.Key)))
                        {
                            location.IsChecked = true;
                        }
                        // Only select stations
                        var stations = locations.Where(l => l.StartsWith("STA~")).ToList();
                        Logging.Verbose("SelectedStations: {stations}", stations);
                        selectedLocations = sessionModel.Locations.Where(l => stations.Contains(l.Key)).OrderBy(l => l.Name).ToList();
                    }
                    Logging.Verbose("SelectedLocations: {@locations}", selectedLocations);
                    sessionModel.SelectedLocations.Clear();
                    sessionModel.SelectedLocations.AddRange(selectedLocations);
                    LoadMapPoints(sessionModel);
                    SessionModel = sessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return GetSelectedLocationsHtml();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetLocationsMap()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("LocationsMap");
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        #endregion

        #region Features
        private async Task<List<Feature>> GetFeaturesList()
        {
            return (await GetList<Feature>("Features")).ToList();
        }

        [HttpGet]
        public JsonResult GetFeatures()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    var result = Json(sessionModel.Features, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetFeaturesHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("FeaturesHtml", SessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetSelectedFeaturesHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("SelectedFeaturesHtml", SessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpPost]
        public PartialViewResult UpdateSelectedFeatures(List<string> features)
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    Logging.Verbose("SelectedFeatures: {features}", features);
                    var sessionModel = SessionModel;
                    var selectedFeatures = new List<Feature>();
                    if (features != null)
                    {
                        // Set IsCheck for all
                        foreach (var feature in sessionModel.Features.Where(i => features.Contains(i.Key)))
                        {
                            feature.IsChecked = true;
                        }
                        // Only select offerings
                        var offerings = features.Where(l => l.StartsWith("OFF~")).ToList();
                        Logging.Verbose("SelectedOfferings: {offerings}", offerings);
                        selectedFeatures = sessionModel.Features.Where(l => offerings.Contains(l.Key)).OrderBy(l => l.Text).ToList();
                    }
                    Logging.Verbose("SelectedFeatures: {@features}", selectedFeatures);
                    sessionModel.SelectedFeatures.Clear();
                    sessionModel.SelectedFeatures.AddRange(selectedFeatures);
                    SessionModel = sessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return GetSelectedFeaturesHtml();
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region Filters
        [HttpGet]
        public PartialViewResult GetFiltersHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    return PartialView("FiltersHtml", SessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpPost]
        public EmptyResult UpdateFilters(DateTime startDate, DateTime endDate)
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    Logging.Verbose("StartDate: {startDate} EndDate: {endDate}", startDate, endDate);
                    var sessionModel = SessionModel;
                    sessionModel.StartDate = startDate;
                    sessionModel.EndDate = endDate;
                    SessionModel = sessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return null;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region DataQuery
        [HttpGet]
        public async Task<EmptyResult> DataQuery()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    var input = new DataQueryInput
                    {
                        Locations = sessionModel.SelectedLocations.Select(i => i.Id).ToList(),
                        Features = sessionModel.SelectedFeatures.Select(i => i.Id).ToList(),
                        StartDate = sessionModel.StartDate,
                        EndDate = sessionModel.EndDate
                    };
                    Logging.Verbose("DataQueryInput: {@input}", input);
                    var results = (await Post<DataQueryInput, DataQueryOutput>("DataQueries", input));
                    //Logging.Verbose("Results: {@results}", results);
                    sessionModel.QueryResults = results;
                    SessionModel = sessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return null;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region ResultsGrid
        [HttpGet]
        public JsonResult GetResultsGridData()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    var result = Json(sessionModel.QueryResults.ResultsGridData, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetResultsGridHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return PartialView("ResultsGridHtml", sessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region ResultsCards
        [HttpGet]
        public PartialViewResult GetResultsCardsHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return PartialView("ResultsCardsHtml", sessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region ResultsChart
        [HttpGet]
        public JsonResult GetResultsChartData()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    var result = Json(sessionModel.QueryResults.ResultsChartData, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpGet]
        public PartialViewResult GetResultsChartHtml()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return PartialView("ResultsChartHtml", sessionModel);
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region LoadQueryDialog
        private async Task<List<UserQuery>> GetUserQueriesList()
        {
            return (await GetList<UserQuery>("UserQueries")).ToList();
        }

        [HttpGet]
        public JsonResult GetUserQueries()
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    var result = Json(sessionModel.UserQueries, JsonRequestBehavior.AllowGet);
                    result.MaxJsonLength = int.MaxValue;
                    return result;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }

        [HttpPost]
        public EmptyResult LoadQuery(LoadQueryModel model)
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    var userQuery = sessionModel.UserQueries.FirstOrDefault(i => i.Name == model.Name);
                    if (userQuery == null) throw new HttpException((int)HttpStatusCode.NotFound, $"UserQuery not found {model.Name}");
                    var input = JsonConvert.DeserializeObject<DataQueryInput>(userQuery.QueryInput);
                    // Locations
                    var selectedLocations = sessionModel.Locations.Where(i => input.Locations.Contains(i.Id));
                    Logging.Verbose("SelectedLocations: {@locations}", selectedLocations);
                    sessionModel.SelectedLocations.Clear();
                    sessionModel.SelectedLocations.AddRange(selectedLocations);
                    foreach (var location in selectedLocations)
                    {
                        location.IsChecked = true;
                    }
                    LoadMapPoints(sessionModel);
                    // Features
                    var selectedFeatures = sessionModel.Features.Where(i => input.Features.Contains(i.Id));
                    Logging.Verbose("SelectedFeatures: {@features}", selectedFeatures);
                    sessionModel.SelectedFeatures.Clear();
                    sessionModel.SelectedFeatures.AddRange(selectedFeatures);
                    foreach (var feature in selectedFeatures)
                    {
                        feature.IsChecked = true;
                    }
                    // Filters
                    sessionModel.StartDate = input.StartDate;
                    sessionModel.EndDate = input.EndDate;
                    sessionModel.QueryResults = new DataQueryOutput();
                    SessionModel = sessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    return null;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion

        #region SaveQueryDialog
        [HttpPost]
        public async Task<EmptyResult> SaveQuery(SaveQueryModel model)
        {
            using (Logging.MethodCall(GetType()))
            {
                try
                {
                    var sessionModel = SessionModel;
                    //Logging.Verbose("Model: {@model}", model);
                    var input = new DataQueryInput
                    {
                        Locations = sessionModel.SelectedLocations.Select(i => i.Id).ToList(),
                        Features = sessionModel.SelectedFeatures.Select(i => i.Id).ToList(),
                        StartDate = sessionModel.StartDate,
                        EndDate = sessionModel.EndDate
                    };
                    var userQuery = new UserQuery
                    {
                        Name = model.Name,
                        Description = model.Description,
                        QueryInput = JObject.FromObject(input).ToString()
                    };
                    //Logging.Verbose("UserQuery: {@UserQuery}", userQuery);
                    await Post<UserQuery, UserQuery>("UserQueries", userQuery);
                    sessionModel.UserQueries = await GetUserQueriesList();
                    SessionModel = sessionModel;
                    return null;
                }
                catch (Exception ex)
                {
                    Logging.Exception(ex);
                    throw;
                }
            }
        }
        #endregion
    }
}