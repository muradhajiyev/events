main_app.controller('category_kind', ['$scope', '$http','$cookieStore','$window','$routeParams', '$location', function ($scope, $http, $cookieStore,$window,$routeParams,$location) 
{       
        // Pagination variables
            $scope.entryLimit = 6; 
            $scope.currentPage = 1;
        
        var kind_id = $routeParams.kind_id;
        var category_id = $routeParams.cat_id;
    
        var token_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
        
        
        
        
    
        var res=$http.post(url_check_token,token_data);
    
        res.success(function(result,config,headers,status)
        {
            if(result!="-1")
            {   
                
                    // Sport category
                    if(category_id == 1) 
                        {
                                sport();
                                function sport(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_sport,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;
                                    });
                                res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                sport();
                                };
                                
                        }
                    // Concert cateory
                    else if(category_id == 2)
                        {
                                concert();
                                function concert(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_concert,objData);

                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;

                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                concert();
                                };
                            }
                    // Seminar category
                    else if(category_id == 3)
                        {

                                seminar();
                                function seminar(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_seminar,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;

                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                seminar();
                                };
                        }
                   // Exhibition category
                    else if (category_id == 4)
                        {      
                                exhibition();
                                function exhibition(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_exhibition,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;

                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                exhibition();
                                };
                        }
                   // Presentation category
                    else if(category_id == 5) 
                        {
                                presentation();
                                function presentation(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_presentation,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;

                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                presentation();
                                };
                        }
                   // Tour category
                    else if(category_id == 6)
                        {
                                tour();
                                function tour(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_tour,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;

                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                tour();
                                };
                        }
                   // Theatre category
                    else if(category_id == 8)
                        {
                                theatre();
                                function theatre(){
                                    var objData ={KIND_ID: kind_id, PAGE: $scope.currentPage};
                                    var res = $http.post(url_kind_theatre,objData);
                                    res.success(function (result, status, headers, config) {
                                                $scope.total_events = parseInt(result.events_count);
                                                $scope.events = result.events;
                                    });
                                    res.error(function (data, status, headers, config) {console.log(result);});
                                }
                                //get another portions of data on page changed
                                $scope.pageChanged = function() {
                                theatre();
                                };
                                }
                    // All sports
                    else if(category_id == 100)
                        {
                             getSport();
                             function getSport() {  
                                var dataObj = { PAGE : $scope.currentPage };
                                var res = $http.post(url_get_sports,dataObj);
                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;

                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             };
                            
                             //get another portions of data on page changed
                            $scope.pageChanged = function() {
                                getSport();
                            };
                                    
                        }
                    // All Seminars
                    else if(category_id == 101)
                        {
                             getSeminar();
                             function getSeminar() {
                                        var dataObj = { PAGE : $scope.currentPage };
                                        var res = $http.post(url_get_seminars,dataObj);
                                        res.success(function (result, status, headers, config) {
                                                 $scope.total_events = parseInt(result.events_count);
                                                 $scope.events = result.events;
                                        });
                                        res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                             $scope.pageChanged = function() {
                                getSeminar();
                            }; 
                        }
                    // All Theatre Performances
                    else if(category_id == 102)
                        {
                             getTheatre();
                             function getTheatre() {
                                var dataObj = { PAGE : $scope.currentPage }; 
                                var res = $http.post(url_get_theatres,dataObj);
                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;

                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                            $scope.pageChanged = function() {
                                getTheatre();
                            }; 
                        }
                    // All Tours
                    else if(category_id == 103)
                        {
                             getTour();
                             function getTour() {
                                var dataObj = { PAGE : $scope.currentPage }; 
                                var res = $http.post(url_get_tours,dataObj);
                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;

                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                            $scope.pageChanged = function() {
                                getTour();
                            }; 
                        }
                    // All Presentations
                    else if(category_id == 104)
                        {
                             getPresentation();
                             function getPresentation() {       
                                var dataObj = { PAGE : $scope.currentPage }; 
                                var res = $http.post(url_get_presentations,dataObj);

                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;
                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                            $scope.pageChanged = function() {
                                getPresentation();
                            }; 
                        }
                    // All Exhibitions
                    else if(category_id == 105)
                        {
                             getExhibition();
                             function getExhibition() {
                                var dataObj = { PAGE : $scope.currentPage }; 
                                var res = $http.post(url_get_exhibitions,dataObj);
                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;

                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                            $scope.pageChanged = function() {
                                getExhibition();
                            };
                        }
                    // All Concerts
                    else if(category_id == 106)
                        {
                             getConcert();
                             function getConcert() {
                                var dataObj = { PAGE : $scope.currentPage }; 
                                var res = $http.post(url_get_concerts,dataObj);
                                res.success(function (result, status, headers, config) {
                                         $scope.total_events = parseInt(result.events_count);
                                         $scope.events = result.events;

                                });
                                res.error(function (data, status, headers, config) {console.log(result);});
                             }
                            
                             //get another portions of data on page changed
                             $scope.pageChanged = function() {
                                getConcert();
                            };
                             }
                
                
            }
            else 
            {
                $window.location.href = "/Login.html"
            }
        });
           res.error(function(result,config,headers,status){
               console.log(result);
           });
            
            $scope.selectPost = function(id,category_id) {
                $location.path('/selectevent/'+id+"/"+category_id);
            }

}]);    