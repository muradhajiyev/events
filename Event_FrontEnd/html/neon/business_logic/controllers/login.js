main_app.controller('login_controller', ['$scope', '$http','$cookieStore','$window', function ($scope, $http, $cookieStore,$window) {
            
            
            $scope.login = function (username, password) 
            {
                
        
                if(username != null && username.length > 0 && password != null && password.length > 0)
                {                    
                    var json_data = JSON.stringify({Username:username,Password:password});
                
                    var res = $http.post(url_Login, json_data);
                
                    res.success(function(result, status, headers, config) 
                        {
                                console.log(result);
                                if(result.Message=='1')
                                    {
                                        $cookieStore.put("token",result.token);
                                        $window.location.href ="index.html"
                                    }
                                 else
                                    {
                                        $window.location.href ="login.html"
                                        document.getElementById('text').innerHTML="The account that you tried to enter does not exist... ";
                                    }
                    
                        }).error(function (data, status, headers, config)
                                 { alert(data);   });
                                
                };
            };
                  
        }
 ]);    
                                                 
        
        