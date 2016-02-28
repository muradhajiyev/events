var url_return_user_id_by_token = server_ip + "api/Tokens/return_id";
main_app
.controller("change_password_controller", function ($window,$location, $scope, $http,$cookieStore) 
        {
            
            $scope.get_user_id = function (new_password,confirm,old_password) 
                {
                
                  if(new_password.length>0 && confirm.length>0 && old_password.length>0)
                  {
                    var json_data =JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                    var res = $http.post(url_return_user_id_by_token,json_data);
                    
                    res.success(function (result, status, headers, config) {
                        
                       $scope.get_user_password(result,new_password,confirm,old_password);
                        
                            
                    }).error(function (data, status, headers, config) {
                        alert(data);
                    });
                    
                  }
                  else
                  {
                      alert("Please,fill out the password box");
                  }
                    
                };
            
                $scope.get_user_password = function(result,new_password,confirm,old_password) {
                    
                    if(new_password==confirm)
                    {                        
                        var json_data1 = JSON.stringify({ID:result,Password:new_password,Old_Password:old_password});
                        var res = $http.post(url_Change_password,json_data1);
                    
                        res.success(function (result, status, headers, config) {
                        
                            alert(result);
                            
                        }).error(function (data, status, headers, config) {
                            alert("no");
                        });
                    }
                    else
                    {
                        alert("Password doesn't match the confirm password");
                    }
                };
            
             
            
            });
  
