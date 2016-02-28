var url_check_token = server_ip + "api/Tokens/check_token";
var url_Add_event_sport = server_ip + "api/Events/Add_event_sport";
var url_Add_event_tour = server_ip + "api/Events/Add_event_tour";
var url_Add_event_seminar = server_ip + "api/Events/Add_event_seminar";
var url_Add_event_presentation = server_ip + "api/Events/Add_event_presentation";
var url_Add_event_theatre = server_ip + "api/Events/Add_event_theatre";
var url_Add_event_exhibition = server_ip + "api/Events/Add_event_exhibition";
var url_Add_event_concert = server_ip + "api/Events/Add_event_concert";
var uploadUrl = server_ip+ "//api/FileUpload/uploadFile";

main_app.controller('modals_controller', ['$scope', '$http','$cookieStore','$window','fileUpload', function ($scope, $http, $cookieStore,$window,fileUpload) {           
			////////////////////////////////////// add event
            $scope.addsport=function()
            {
                                                                                                                         
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.title_sport == '' ||  $scope.title_sport == undefined ||
						   $scope.adress == '' ||  $scope.adress_sport == undefined ||
						   $scope.description_sport == '' ||  $scope.description_sport == undefined ||
						   $scope.price_sport == '' ||  $scope.price_sport == undefined ||
						   $scope.cost_sport == '' ||  $scope.cost_sport == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_sport == '' ||  $scope.kind_sport == undefined ||
						   document.getElementById("start_date_sport").value =='' ||
						   document.getElementById("start_date_sport").value == undefined ||
						   document.getElementById("end_date_sport").value =='' || 
						   document.getElementById("end_date_sport").value == undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
                                          
                            
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
							
                        var json_data1={
                            CATEGORY_ID:1,
                            TITLE:$scope.title_sport,
                            ADDRESS:$scope.adress_sport,
                            DESCRIPTION:$scope.description_sport,
                            PRICE:$scope.price_sport,
                            PRICE_COST:$scope.cost_sport,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_sport").value,
                            END_DATE:document.getElementById("end_date_sport").value,
                            KIND_ID:$scope.kind_sport,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        };
                        var res1=$http.post(url_Add_event_sport,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
									$window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(result,config,headers,status){ console.log(result);});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(result,config,headers,status){console.log(result);});
            }
			
			/////////////////////////////////////////////////////////////////
			
			
			///////////////////////////////////// add tours
			 $scope.addtour=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.title_tour == '' ||  $scope.title_tour == undefined ||
						   $scope.adress_tour == '' ||  $scope.adress_tour == undefined ||
						   $scope.description_tour == '' ||  $scope.description_tour == undefined ||
						   $scope.price_tour == '' ||  $scope.price_tour == undefined ||					   
						   $scope.destination_tour == '' ||  $scope.destination_tour == undefined ||
						   $scope.transportation_tour == '' ||  $scope.transportation_tour == undefined ||
						   $scope.point_tour == '' ||  $scope.point_tour == undefined ||
						   $scope.organizer_tour == '' ||  $scope.organizer_tour == undefined ||						   
						   $scope.cost_tour == '' ||  $scope.cost_tour == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_tour == '' ||  $scope.kind_tour == undefined ||
						   document.getElementById("start_date_tour").value =='' ||
						   document.getElementById("start_date_tour").value==undefined ||
						   document.getElementById("end_date_tour").value =='' || 
						   document.getElementById("end_date_tour").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
							
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
                            
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:6,
							AUTHOR : $scope.author_tour,
                            TITLE:$scope.title_tour,
                            ADDRESS:$scope.adress_tour,
                            DESCRIPTION:$scope.description_tour,
							DESTINATION : $scope.destination_tour,
                            TRANSPORTATION:$scope.transportation_tour,
                            ASSEMBLING_POINT:$scope.point_tour,
                            ORGANIZER:$scope.organizer_tour,
                            PRICE:$scope.price_tour,
                            PRICE_COST:$scope.cost_tour,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_tour").value,
                            END_DATE:document.getElementById("end_date_tour").value,
                            KIND_ID:$scope.kind_tour,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_tour,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			
			////////////////////////////////////////////////////////////////////////////
			
			
			/////////////////////////////// add seminar
			  $scope.addseminar=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.subject_seminar == '' ||  $scope.subject_seminar == undefined ||
						   $scope.author_seminar == '' ||  $scope.author_seminar == undefined ||
						   $scope.title_seminar == '' ||  $scope.title_seminar == undefined ||
						   $scope.adress_seminar == '' ||  $scope.adress_seminar == undefined ||
						   $scope.description_seminar == '' ||  $scope.description_seminar == undefined ||
						   $scope.price_seminar == '' ||  $scope.price_seminar == undefined ||					   
						   $scope.cost_seminar == '' ||  $scope.cost_seminar == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_seminar == '' ||  $scope.kind_seminar == undefined ||
						   document.getElementById("start_date_seminar").value =='' ||
						   document.getElementById("start_date_seminar").value==undefined ||
						   document.getElementById("end_date_seminar").value =='' || 
						   document.getElementById("end_date_seminar").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
                            
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
							
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:3,
							AUTHOR : $scope.author_seminar,
						    SUBJECT:$scope.subject_seminar,
                            TITLE:$scope.title_seminar,
                            ADDRESS:$scope.adress_seminar,
                            DESCRIPTION:$scope.description_seminar,
                            PRICE:$scope.price_seminar,
                            PRICE_COST:$scope.cost_seminar,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_seminar").value,
                            END_DATE:document.getElementById("end_date_seminar").value,
                            KIND_ID:$scope.kind_seminar,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_seminar,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			
			
			//////////////////// add presentation
			  
			  $scope.addpresentation=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.author_presentation == '' ||  $scope.author_presentation == undefined ||
						   $scope.title_presentation == '' ||  $scope.title_presentation == undefined ||
						   $scope.adress_presentation == '' ||  $scope.adress_presentation == undefined ||
						   $scope.description_presentation == '' ||  $scope.description_presentation == undefined ||
						   $scope.price_presentation == '' ||  $scope.price_presentation == undefined ||
						   $scope.cost_presentation == '' ||  $scope.cost_presentation == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_presentation == '' ||  $scope.kind_presentation == undefined ||
						   document.getElementById("start_date_presentation").value =='' ||
						   document.getElementById("start_date_presentation").value==undefined ||
						   document.getElementById("end_date_presentation").value =='' || 
						   document.getElementById("end_date_presentation").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
                            
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
							
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:5,
							AUTHOR : $scope.author_presentation,
                            TITLE:$scope.title_presentation,
                            ADDRESS:$scope.adress_presentation,
                            DESCRIPTION:$scope.description_presentation,
                            PRICE:$scope.price_presentation,
                            PRICE_COST:$scope.cost_presentation,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_presentation").value,
                            END_DATE:document.getElementById("end_date_presentation").value,
                            KIND_ID:$scope.kind_presentation,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_presentation,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			  
			  //////////////////////// add theatre
			  
			  
			    $scope.addtheatre=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.senarist_theatre == '' ||  $scope.senarist_theatre == undefined ||
						   $scope.producer_theatre == '' ||  $scope.producer_theatre == undefined ||
						   $scope.organizer_theatre == '' ||  $scope.organizer_theatre == undefined ||
						   $scope.title_theatre == '' ||  $scope.title_theatre == undefined ||
						   $scope.adress_theatre == '' ||  $scope.adress_theatre== undefined ||
						   $scope.description_theatre == '' ||  $scope.description_theatre == undefined ||
						   $scope.price_theatre == '' ||  $scope.price_theatre == undefined ||
						   $scope.cost_theatre == '' ||  $scope.cost_theatre == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_theatre == '' ||  $scope.kind_theatre == undefined ||
						   document.getElementById("start_date_theatre").value =='' ||
						   document.getElementById("start_date_theatre").value==undefined ||
						   document.getElementById("end_date_theatre").value =='' || 
						   document.getElementById("end_date_theatre").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
							
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
                            
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:8,
							SENARIST : $scope.senarist_theatre,
							PRODUCER : $scope.producer_theatre,
							ORGANIZER : $scope.organizer_theatre,
                            TITLE:$scope.title_theatre,
                            ADDRESS:$scope.adress_theatre,
                            DESCRIPTION:$scope.description_theatre,
                            PRICE:$scope.price_theatre,
                            PRICE_COST:$scope.cost_theatre,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_theatre").value,
                            END_DATE:document.getElementById("end_date_theatre").value,
                            KIND_ID:$scope.kind_theatre,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_theatre,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			
			/////////////////// add exhibition
			
			 $scope.addexhibition=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.author_exhibition == '' ||  $scope.author_exhibition == undefined ||
						   $scope.title_exhibition == '' ||  $scope.title_exhibition == undefined ||
						   $scope.adress_exhibition == '' ||  $scope.adress_exhibition == undefined ||
						   $scope.description_exhibition == '' ||  $scope.description_exhibition == undefined ||
						   $scope.price_exhibition == '' ||  $scope.price_exhibition == undefined ||
						   $scope.cost_exhibition == '' ||  $scope.cost_exhibition == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_exhibition == '' ||  $scope.kind_exhibition == undefined ||
						   document.getElementById("start_date_exhibition").value =='' ||
						   document.getElementById("start_date_exhibition").value==undefined ||
						   document.getElementById("end_date_exhibition").value =='' || 
						   document.getElementById("end_date_exhibition").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
							
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
                            
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:4,
							AUTHOR : $scope.author_exhibition,
                            TITLE:$scope.title_exhibition,
                            ADDRESS:$scope.adress_exhibition,
                            DESCRIPTION:$scope.description_exhibition,
                            PRICE:$scope.price_exhibition,
                            PRICE_COST:$scope.cost_exhibition,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_exhibition").value,
                            END_DATE:document.getElementById("end_date_exhibition").value,
                            KIND_ID:$scope.kind_exhibition,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_exhibition,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			
			
			
			
			/////////////////////////////////////  add concert
			 
			 
			 $scope.addconcert=function()
            {
                var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
                var res=$http.post(url_check_token,json_data);
                
                res.success(function(result,config,headers,status)
                {
					var user_id=result;
                    if(result !='-1') // bu shert odenerse result userin id-sidi
                    {
						if($scope.singer_concert == '' ||  $scope.singer_concert == undefined ||
						   $scope.organizer_concert == '' ||  $scope.organizer_concert == undefined ||
						   $scope.title_concert == '' ||  $scope.title_concert == undefined ||
						   $scope.adress_concert == '' ||  $scope.adress_concert == undefined ||
						   $scope.description_concert == '' ||  $scope.description_concert == undefined ||
						   $scope.price_concert == '' ||  $scope.price_concert == undefined ||
						   $scope.cost_concert == '' ||  $scope.cost_concert == undefined ||
						   $scope.lat == '' ||  $scope.lat == undefined ||
						   $scope.lang == '' ||  $scope.lang == undefined ||
						   $scope.kind_concert == '' ||  $scope.kind_concert == undefined ||
						   document.getElementById("start_date_concert").value =='' ||
						   document.getElementById("start_date_concert").value==undefined ||
						   document.getElementById("end_date_concert").value =='' || 
						   document.getElementById("end_date_concert").value==undefined
						  )
						{
							alert("Please fill out all boxes");
						}
						else{
                            
                            var file = $scope.myFile;
                            console.dir(file);
                            fileUpload.uploadFileToUrl(file, uploadUrl);
							
                        var json_data1=JSON.stringify({
                            CATEGORY_ID:2,
							SINGER : $scope.singer_concert,
							ORGANIZER : $scope.organizer_concert,
                            TITLE:$scope.title_concert,
                            ADDRESS:$scope.adress_concert,
                            DESCRIPTION:$scope.description_concert,
                            PRICE:$scope.price_concert,
                            PRICE_COST:$scope.cost_concert,
                            LONGITUDE:$scope.lang,
                            LATITUDE:$scope.lat,
                            START_DATE:document.getElementById("start_date_concert").value,
                            END_DATE:document.getElementById("end_date_concert").value,
                            KIND_ID:$scope.kind_concert,
                            LOGO_NAME:file.name,
                            CREATED_BY:user_id
                        })
                        var res1=$http.post(url_Add_event_concert,json_data1);
                        res1.success(function(result,config,headers,status)
                        {
                                if(result!='-1')
                                {
                                    alert("Event added");
                                    $window.location.href = "/index.html"
                                }
                                else
                                {
                                    alert("Try again");   
                                }
                        
                        });
                        res1.error(function(status,config,headers,result){});
						}
                    }
                    else 
                    {
                        $window.location.href = "/Login.html"
                    }
                    
                });
                res.error(function(status,config,headers,result){});
            }
			
			///////////////////////////////////////////////////
			

			
			
			
			
		///////////////////////////////// set mapp
			var markers = [];
			var myCenter=new google.maps.LatLng(42,44);
			
        
        $scope.set_event=function(){
            
	     	google.maps.event.addDomListener(window, 'load', initialize());
            
        }
        
		function initialize() {
        
            window.setTimeout(function(){
                                                      
                    google.maps.event.trigger(map, 'resize');
                                                     
            },1000);
			var mapProp = {
							center:myCenter,
							zoom:7,
                            panControl:true,
                            zoomControl:true,
                            mapTypeControl:true,
                            scaleControl:true,
                            streetViewControl:true,
                            overviewMapControl:true,
                            rotateControl:true,    
							mapTypeId:google.maps.MapTypeId.ROADMAP
						  };
			var map=new google.maps.Map(document.getElementById("googleMap"),mapProp);
			
			/*
			var marker=new google.maps.Marker({
				position:myCenter,
				title:'Go To Address'
			});

			marker.setMap(map);
			
			var infowindow = new google.maps.InfoWindow({
				content:"Baku!"
			});

			infowindow.open(map,marker);
			
			google.maps.event.addListener(marker,'click',function() {
				map.setZoom(10);
				map.setCenter(marker.getPosition());
			});
			
			*/
            
			google.maps.event.addListener(map, 'click', function(event) {
				DeleteMarkers();
				$scope.lang=event.latLng.lng();
				$scope.lat=event.latLng.lat();
				
				var marker = new google.maps.Marker({
					position: event.latLng,
					map: map,
				});
			
				var infowindow = new google.maps.InfoWindow({
					content: 'Latitude: ' + event.latLng.lat() +
					'<br>Longitude: ' + event.latLng.lng()
				});
				infowindow.open(map,marker);
				
				markers.push(marker);
			});
		}
		
		function DeleteMarkers() {
		// alert("yes");
			for (var i = 0; i < markers.length; i++) {
				markers[i].setMap(null);
			}
			markers = [];
		};
		///////////////////////////////////// map
			
			
			$scope.clean_models=function()
			{
				$scope.lang=0;
				$scope.lat=0;
			}
			
			
        }
										 
										 
 ]);    
                                                 
        
        