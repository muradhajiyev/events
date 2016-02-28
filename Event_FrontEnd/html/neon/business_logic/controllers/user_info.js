//var url_check_token = server_ip + "api/Tokens/check_token";
//var user_info_by_token = server_ip + "/api/Tokens/user_info_by_token";

main_app
.controller("index_controller1", function ($scope, $http, $location, $window, $cookieStore)
 {
  
    $scope.login = function () 
    {
        
        var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
        var res=$http.post(url_check_token,json_data);
        res.success(function(result,config,headers,status)
        {
            
            if(result !="-1") // bu shert odenerse result userin id-sidi
            {
                
                var json_data1 = JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                var res1 = $http.post(user_info_by_token,json_data1);
                res1.success(function(result,config,headers,status)
                {
                   
                    //var users = [];
   
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
                    
                  //  $scope.users = users;
                    
                });
                
                res1.error(function(status,config,result,headers){});
                            
            }
            else 
            {
                $window.location.href = "/Login.html"
            }
        });

        res.error(function(status,config,headers,result){});
        
    }

    
});
 
