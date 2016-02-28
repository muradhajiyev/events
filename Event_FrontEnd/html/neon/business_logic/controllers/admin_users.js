//document.getElementById("btnPlaceOrder").disabled = true; ///lazim olacaq
main_app.controller("admin_users", function ($scope, $http, $location, $window, $cookieStore)//ng-app of admin--panel
 {
     if($cookieStore.get("token") == undefined)
     {
     $window.location.href = "/login.html";
     }
     $scope.selected_user_model = null;
    
    $scope.edit_user_model = function(user_model){
        
        $scope.selected_user_model = user_model;
        
        console.log($scope.selected_user_model);
        
          alertify.genericDialog || alertify.dialog('genericDialog',function(){
       return {
        main:function(content){
            this.setContent(content);
        },
        setup:function(){
            return {
                focus:{
                    element:function(){
                        return this.elements.body.querySelector(this.get('selector'));
                    },
                    select:true
                },
                options:{
                    basic:true,
                    maximizable:false,
                    resizable:false,
                    padding:false
                }
            };
        },
        settings:
        {
            selector:undefined
        }
      };
    });
    //force focusing password box
    alertify.genericDialog ($('#editForm')[0]).set('selector', 'input[type="text"]');
        
       
         
    
    }
    
     
         
    var users = [];        
    var res2=$http.post(url_Get_all_users);
                                res2.success(function(result,config,headers,status)
                                {
                                     for(var i=0;i<result.length;i++)
                                     {
                                        if(result[i].ADMIN!='1'){
                                        users.push
                                        (
                                           {
                                            Id:result[i].ID,
                                            Name:result[i].NAME,
                                            Surname:result[i].SURNAME,
                                            Username:result[i].USERNAME,
                                            Email:result[i].EMAIL,
                                            Logo_Image:result[i].IMAGE,
                                            Birthday:result[i].BIRTHDAY,
                                            Created_by:result[i].CREATED_BY,
                                            Updated_by:result[i].UPDATED_BY,
                                            Gender:result[i].GENDER,
                                            Status:result[i].STATUS,
                                            Added_by:result[i].ADDED_BY,
                                            Edited_by:result[i].EDITED_BY,
                                            Modified_by:result[i].MODIFIED_BY
                                           }
                                        )
                                        $scope.users = users;
                                        
                                      }}
                                    
                                });//succesin moterizesi

                                res2.error(function(status,config,headers,result){});
                
        
    //////////////////////////////////////////////////////////////////////////////////////////////////////////
    
   
    
    ///////addinngggggggggggggggg userrrrrrrrrrrrrrrrrr//////////////////////////////////////////////////////////////
    
    
    
    $scope.adduser = function () {

       alertify.genericDialog || alertify.dialog('genericDialog',function(){
    return {
        main:function(content){
            this.setContent(content);
        },
        setup:function(){
            return {
                focus:{
                    element:function(){
                        return this.elements.body.querySelector(this.get('selector'));
                    },
                    select:true
                },
                options:{
                    basic:true,
                    maximizable:false,
                    resizable:false,
                    padding:false
                }
            };
        },
        settings:{
            selector:undefined
        }
    };
});
//force focusing password box
alertify.genericDialog ($('#addForm')[0]).set('selector', 'input[type="password"]');
        
    };

    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    
     $scope.add = function (username,password,name,surname,email,gender) {

        $scope.username = username.trim();
        $scope.password = password.trim();
        $scope.name = name.trim();
        $scope.surname = surname.trim();
        $scope.email = email.trim();
        $scope.gender = gender.trim();
       // $scope.image = image;
        if (username != "" && name != "" && surname != "" && email != "" && email.indexOf('@') != -1)
        {


                                    var json_data1 = JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                                    var res1 = $http.post(user_info_by_token,json_data1);
                                    $scope.added_by_id = null;
                                    res1.success(function(result,config,headers,status)
                                                 {
                                                    var jsonData4 = 
                                                    {
                                                    USERNAME:username,
                                                    PASSWORD: password,
                                                    NAME: name,
                                                    SURNAME: surname,
                                                    EMAIL: email,
                                                    GENDER: gender,
                                                    //IMAGE:image,
                                                    CREATED_BY:result.ID,
                                                    UPDATED_BY:result.ID,
                                                    MODIFIED_STATUS_BY:result.ID
                                                    };
            var res4 = $http.post(url_Insert_user, jsonData4);

            res4.success(function (result, data, status, headers)
            {
                console.log(result);

                if (result == -4)
                {
                    document.getElementById("show_message2").innerHTML = '<p style="text-align:center">This username already exists</p>';

                }
                else 
                {
                    
                    document.getElementById("show_message2").innerHTML = '<p style="text-align:center">You succesfully added the user!</p>';
                    //$window.location.reload();
                }

            });
                                                 });
            
                
                                    res1.error(function(status,config,result,headers){});
            
            

            

        }

    }

     
     ///////////////////////////////////////////////////////////////////////////////
     ///delete user///////////////////////////////////////////////////////////////////
     
   $scope.Delete_user = function (id) 
    {  
                    alertify.confirm('Are you sure to delete?!!',
                        function(){ alertify.success('Ok'); 
                                   
                        var json_data = JSON.stringify({ID:id});
                        var res = $http.post(url_Delete_user,json_data);
                        res.success(function(result,headers,status,config)
                        {
                    
                            console.log(result);
                            if(result==1)
                            {
                                
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
     
    
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    
     $scope.edit = function (selected_user_model) {

        $scope.id = selected_user_model.Id;
        $scope.username = selected_user_model.Username;
        $scope.name = selected_user_model.Name;
        $scope.surname = selected_user_model.Surname;
        $scope.email = selected_user_model.Email;
        $scope.gender = selected_user_model.Gender;
       // $scope.image = image;
        if ($scope.username != "" && $scope.name != "" && $scope.surname != "" && $scope.email != "" && $scope.email.indexOf('@') != -1)
        {


                                    var json_data1 = JSON.stringify({TOKEN_Values:$cookieStore.get("token")});
                                    var res1 = $http.post(user_info_by_token,json_data1);
                                    res1.success(function(result,config,headers,status)
                                                 {
                                        var jsonData4 = {
                                        ID:$scope.id,
                                        USERNAME:$scope.username,
                                        NAME: $scope.name,
                                        SURNAME: $scope.surname,
                                        EMAIL: $scope.email,
                                        GENDER: $scope.gender,
                                        //IMAGE:image,
                                        UPDATED_BY:result.ID
                                                        };
                                        var res4 = $http.post(url_Update_user, jsonData4);
            res4.success(function (result, data, status, headers)
            {
                console.log(result);
                if (result == 3)
                {
                    document.getElementById("show_message2").innerHTML = '<p style="text-align:center">Update is succesfull!!</p>';
                    $window.location.reload();
                }
                else 
                {
                    document.getElementById("show_message2").innerHTML = '<p style="text-align:center">Update is not succesfull!</p>';
                }
                $window.location.reload();

            });
                                                    
                                                 });
                
                 res1.error(function(status,config,result,headers){});
            
            

            

        }

    }
     
     //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    
});










