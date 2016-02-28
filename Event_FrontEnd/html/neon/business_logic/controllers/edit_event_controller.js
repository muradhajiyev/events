main_app.controller('edit_event_controller', function($scope,$http,$rootScope,$cookieStore,$routeParams,$location) {
            
        var id = $routeParams.id;
        var category_id = $routeParams.cat_id;
        var dataObj = { ID : id };
        
    if(category_id == 1)
        {   
                    
                var res = $http.post(url_select_event_sport,dataObj);
                
                res.success(function(result,config,headers,status) {
                                            
                                            $scope.sport=[

                                                           result
                                                        ];

					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);


                    });

                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
            
                $scope.updatesport=function(event)
							{		

								var res1=$http.post(url_UpdateSport,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
            
        }
    else if(category_id == 2)
        {
                
                var res = $http.post(url_select_event_concert,dataObj);
                var concert = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.concert=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
                $scope.updateconcert=function(event)
							{		

								var res1=$http.post(url_UpdateConcert,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        }
    else if(category_id == 3)
        {
            
                var res = $http.post(url_select_event_seminar,dataObj);
                res.success(function(result,config,headers,status) {
                        
                                            $scope.seminar=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
                $scope.updateseminar = function(event)
							{		

								var res1=$http.post(url_UpdateSeminar,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        }
    else if(category_id == 4)
        {
            var res = $http.post(url_select_event_exhibition,dataObj);
                var exhibition = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.exhibition=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
            $scope.updateexhibition = function(event)
							{		

								var res1=$http.post(url_UpdateExhibition,event);
								res1.success(function(result){
							
									if(result == 1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        }
    else if(category_id == 5)
        {
                var res = $http.post(url_select_event_presentation,dataObj);
                var presentation = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.presentation=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
                    $scope.updatepresentation = function(event)
							{		

								var res1=$http.post(url_UpdatePresentation,event);
								res1.success(function(result){
							
									if(result == 1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        }
    else if(category_id == 6)
        {
                var res = $http.post(url_select_event_tour,dataObj);
                res.success(function(result,config,headers,status) {
                        
                                            $scope.tour=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
            $scope.updatetour = function(event)
							{		

								var res1=$http.post(url_UpdateTour,event);
								res1.success(function(result){
							
									if(result == 1)
									{
                                     
                                        alert('Event updated');
                                        
									}
									else
									{
                                        alert('Please, Try again');
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        }
    else if(category_id == 8)
        {
                var res = $http.post(url_select_event_theatre,dataObj);
                var theatre = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.theatre=[

                                                           result
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
            $scope.updatetheatre = function(event)
							{		

								var res1=$http.post(url_UpdateTheatre,event);
								res1.success(function(result){
							
									if(result == 1)
									{
										alert("Event updated");
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
        };
	
	
	function setting_map(lang,lat,address){
		
        			myCenter=new google.maps.LatLng(lat,lang);
			
					google.maps.event.addDomListener(window, 'load', initialize());
            
        
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
						var map=new google.maps.Map(document.getElementById("show_map"),mapProp);
			
			
						var marker=new google.maps.Marker({
							position:myCenter,
							title:'Go To Address'
						});

						marker.setMap(map);
			
						var infowindow = new google.maps.InfoWindow({
							content: address
						});

						infowindow.open(map,marker);
			
						google.maps.event.addListener(marker,'click',function() {
							map.setZoom(10);
							map.setCenter(marker.getPosition());
						});
						
					};
		
					
	
				};
    
    // select any editable event which has been clicked
            $scope.selectPost1 = function(id,category_id) {
                $location.path('/editevent/'+id+"/"+category_id);
            }
        
})