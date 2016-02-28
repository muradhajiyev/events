var server_ip = "http://localhost/events/";

var url_Login = server_ip + "api/Users/Login";
var url_Logout = server_ip + "api/Users/logout";
var url_Get_all_users = server_ip + "api/Users/get";
var url_Deactivating_user = server_ip + "api/Users/Deactivating_user";
var url_Activating_user = server_ip + "api/Users/Activating_user";
var url_Change_password = server_ip + "api/Users/Change_password";
var url_Update_user = server_ip + "api/Users/edit";
var url_Insert_user = server_ip + "api/Users/add";
var url_Delete_user = server_ip + "api/Users/delete";

//events action methods 

var url_UpdateSport = server_ip + "api/Events/UpdateSport";
var url_UpdateSeminar = server_ip + "api/Events/UpdateSeminar";
var url_UpdatePresentation = server_ip + "api/Events/UpdatePresentation";
var url_UpdateTheatre = server_ip + "api/Events/UpdateTheatre";
var url_UpdateTour = server_ip + "api/Events/UpdateTour";
var url_UpdateConcert = server_ip + "api/Events/UpdateConcert";
var url_UpdateExhibition = server_ip + "api/Events/UpdateExhibition";
var url_Add_event_sport = server_ip + "api/Events/Add_event_sport";
var url_Add_event_seminar = server_ip + "api/Events/Add_event_seminar";
var url_Add_event_presentation = server_ip + "api/Events/Add_event_presentation";
var url_Add_event_theatre = server_ip + "api/Events/Add_event_theatre";
var url_Add_event_tour = server_ip + "api/Events/Add_event_tour";
var url_Add_event_concert = server_ip + "api/Events/Add_event_concert";
var url_Add_event_exhibition = server_ip + "api/Events/Add_event_exhibition";
var url_get_sports = server_ip + "api/Events/get_sport_events";
var url_get_theatres = server_ip + "api/Events/get_theatre_events";
var url_get_tours = server_ip + "api/Events/get_tour_events";
var url_get_seminars = server_ip + "api/Events/get_seminar_events";
var url_get_presentations = server_ip + "api/Events/get_presentation_events";
var url_get_exhibitions = server_ip + "api/Events/get_exhibition_events";
var url_get_concerts = server_ip + "api/Events/get_concert_events";
var url_get_all_events = server_ip + "api/Events/get_all_events";
var url_select_event_sport = server_ip + "api/Events/select_sport_event";
var url_select_event_concert = server_ip + "api/Events/select_concert_event";
var url_select_event_seminar = server_ip + "api/Events/select_seminar_event";
var url_select_event_exhibition = server_ip + "api/Events/select_exhibition_event";
var url_select_event_presentation = server_ip + "api/Events/select_presentation_event";
var url_select_event_tour = server_ip + "api/Events/select_tour_event";
var url_select_event_theatre = server_ip + "api/Events/select_theatre_event";

var delete_sport = server_ip + "api/Events/delete_sport";
var delete_concert = server_ip + "api/Events/delete_concert";
var delete_tour = server_ip + "api/Events/delete_tour";
var delete_theatre = server_ip + "api/Events/delete_theatre";
var delete_seminar = server_ip + "api/Events/delete_seminar";
var delete_presentation = server_ip + "api/Events/delete_presentation";
var delete_exhibition = server_ip + "api/Events/delete_exhibition";

var url_kind_sport=server_ip + "api/Events/kind_sport";
var url_kind_seminar=server_ip + "api/Events/kind_seminar";
var url_kind_theatre=server_ip + "api/Events/kind_theatre";
var url_kind_tour=server_ip + "api/Events/kind_tour";
var url_kind_exhibition=server_ip + "api/Events/kind_exhibition";
var url_kind_concert=server_ip + "api/Events/kind_concert"; 
var url_kind_presentation = server_ip + "api/Events/kind_presentation"



//news action methods

var url_add_news = server_ip + "api/News/add_news";
var url_get_all_news = server_ip + "api/News/get_all_news";
var url_update_news = server_ip + "api/News/update_news";
var url_delete_news = server_ip + "api/News/delete_news";

//tokens action methods

var url_check_token = server_ip + "api/Tokens/check_token";
var url_get_token_for_logged_user = server_ip + "/api/Users/token";
var get_user_info_by_token = server_ip + "/api/Tokens/get_user_info_by_token";
var get_user_id_by_token = server_ip + "/api/Tokens/return_id";
var user_info_by_token = server_ip + "/api/Tokens/user_info_by_token";

//variables 
var user_login = "authorized_user";
var saved_password = "user_password";
var token = "user_token";

//,'ui.bootstrap'

// App Module
var main_app = angular.module("mainApp", ['ngCookies', 'ngRoute','ui.bootstrap']); 

main_app.config(['$routeProvider', function($routeProvider) {
                                                 
                        $routeProvider
                                .when('/', {
                                                 templateUrl: 'homepage.html',
                                                 controller:  'homepage_controller'
                                })
                                .when('/contact', {
                                                templateUrl: 'contactpage.html'
                                })
                                .when('/about', {
                                                templateUrl: 'aboutpage.html'
                                })
                                .when('/news', {
                                                templateUrl: 'newspage.html',
                                                controller:  'news_controller'
                                }).when('/userprofile', {
                                                templateUrl: 'userprofile.html'
                                })
                                .when('/selectevent/:id/:cat_id', {
                                                templateUrl: 'select_event.html',
                                                controller:  'select_event_controller'
                                })
                                .when('/editevent/:id/:cat_id', {
                                                templateUrl: 'edit_events.html',
                                                controller:   'edit_event_controller'
                                })
                                .when('/categories/:kind_id/:cat_id', {
                                                templateUrl: 'homepage.html',
                                                controller:  'category_kind'
                                })
                                .when('/admin_user_panel', {
                                                templateUrl: 'admin_users.html',
                                                controller:  'admin_users'
                        });
                                
                      }]);



// upload file
main_app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function(scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            
            element.bind('change', function(){
                scope.$apply(function(){
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

main_app.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function(file, uploadUrl){
        var fd = new FormData();
        fd.append('UploadedImage', file);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: {'Content-Type': undefined}
        })
        .success(function(result){
            console.log("Image was uploaded succesfully: "+ result);
        })
        .error(function(result){
            console.log("The image couldn't be uploaded: "+result);
        });
    }
}]);