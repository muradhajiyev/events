main_app.controller('homepage_controller', function($scope, $location, $http, $cookieStore,$rootScope,$cookieStore,$window)
{    

        if($cookieStore.get("token") == undefined)  $window.location.href = "/login.html"
 
            
            // Pagination variables
            $scope.entryLimit = 6; 
            $scope.currentPage = 1;
    
            getData();
    
            function getData() {
                
                var dataObj = { PAGE : $scope.currentPage };
                var res = $http.post(url_get_all_events, dataObj);
                res.success(function(result,config,headers,status) {
                                    
                                    $scope.total_events = parseInt(result.events_count) ;
                                    $scope.events = result.events;
                });
                
                res.error(function(result,config,headers,status) {
                    console.log(result);
                });
                
            
            }
            
            //get another portions of data on page changed
            $scope.pageChanged = function() {
                getData();
            };
        
            // select any event which has been clicked
            $scope.selectPost = function(id,category_id) {
                $location.path('/selectevent/'+id+"/"+category_id);
            }
            
            // select any editable event which has been clicked
            $scope.editPost = function(id,category_id) {
                $location.path('/editevent/'+id+"/"+category_id);
            }
            
            
            // delete any event which has been clicked
            $scope.delete = function (obj) {
         
                var dataObj = { ID : obj.ID };
                var category_id = obj.CATEGORY_ID;
                var id = obj.ID;

                if(category_id == 1)
                    {   
                                   alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_sport,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                            $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 

                    }
                else if(category_id == 2)
                    {
                                    alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_concert,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {

                                        console.log(result);
                                        if(result==1)
                                        {
                                            console.log(result);
                                        }

                                        else
                                        {

                                            $window.location.reload();
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }
                else if(category_id == 3)
                    {

                              alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_seminar,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                            $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }
                else if(category_id == 4)
                    {
                          alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_exhibition,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                            $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }
                else if(category_id == 5)
                    {
                             alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_presentation,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                           $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }
                else if(category_id == 6)
                    {
                              alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_tour,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                            $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }
                else if(category_id == 8)
                    {
                              alertify.confirm('Are you sure to delete?!!',
                                    function(){ alertify.success('Ok'); 

                                    var res = $http.post(delete_theatre,dataObj);
                                    res.success(function(result,headers,status,config)
                                    {
                                        console.log(result);
                                        if(result==1)
                                        {

                                        }

                                        else
                                        {

                                            $window.alert("could not delete the event");
                                        }

                                        $window.location.reload();

                                    });

                                    res.error(function(result,headers,status,config)
                                    {
                                            console.log(result);
                                        //    $window.alert("There is a problem in the connection  try again!");  $window.location.reload();  
                                    });



                                    },

                                    function(){ alertify.error('Cancel');})
                                    .set('defaultFocus', 'cancel'); 
                    }   

             }
                                
                      
});


    
           
        
    