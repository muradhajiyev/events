main_app.controller('index_controller', function ($window, $scope, $http,$cookieStore) 
        {
            if($cookieStore.get("token") == undefined) $window.location.href ="login.html";
            
            $scope.logout = function () 
                {
                
                    var json_data =JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                    var res = $http.post(url_Logout,json_data);
                    
                    res.success(function (result, status, headers, config) {
                        $cookieStore.remove('token');
                        $window.location.href ="login.html"
                    
                            
                    }).error(function (data, status, headers, config) {
                       // alert(data);
                    });
                    

                };
            
            
                                    // user info by token
                                    var json_data = JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                                    var res = $http.post(user_info_by_token,json_data);
                                    res.success(function(result,config,headers,status)
                                                 {
   
                                            $scope.users=[
                    
                                                {
                                                    Name:result.NAME,
                                                    Surname:result.SURNAME,
                                                    Username:result.USERNAME,
                                                    Email:result.EMAIL,
                                                    Logo_Image:result.IMAGE,
                                                    Birthday:result.BIRTHDAY,
                                                    Gender:result.GENDER                             
                                                }
                                            ];
                    
                                    });
                
                                    res.error(function(result,config,status,headers){ console.log(result)});
                            


            
        });
  
        
