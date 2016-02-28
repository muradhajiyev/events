main_app.controller('event_update', function($scope, $location, $http, $cookieStore,$rootScope,$cookieStore,$window){
	var json_data = JSON.stringify({TOKEN_Values : $cookieStore.get("token")});
	var ress=$http.post(url_check_token,json_data);
	ress.success(function(result,config,headers,status)
	{
		
			if(result !="-1") // bu shert odenerse result userin id-sidi
            {
                var user_id=result;
				
				var lang;
				var lat;			
				var lang_new;
			   	var lat_new;
				
				var myCenter=new google.maps.LatLng();
				$rootScope.call_modal = function(event_old){		
					if(event_old.CATEGORY_ID == 1)
					{      alert("TEST1");
						$('#modal-1').modal('show', {backdrop: 'static'}); 
				
				    	var jsondata = JSON.stringify({ID : event_old.ID});
						var res=$http.post(url_select_event_sport,jsondata);
				
						res.success(function(result){
					
							$scope.sport_data = result;
							//document.getElementById("sport_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updatesport=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateSport,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
				 	
				
					}
					
					else if(event_old.CATEGORY_ID == 2)
					{ 
						jQuery('#modal-7').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_concert,jsondata);
				
						res.success(function(result){
					
							$scope.concert_data = result;
							//document.getElementById("concert_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updateconcert=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateConcert,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					}
				
					else if(event_old.CATEGORY_ID == 3)
					{ 
						jQuery('#modal-2').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_seminar,jsondata);
				
						res.success(function(result){
					
							$scope.seminar_data = result;
							//document.getElementById("seminar_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updateseminar=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateSeminar,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					
					
					}
				
					else if(event_old.category_id == 4)
					{ 
						jQuery('#modal-6').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_exhibition,jsondata);
				
						res.success(function(result){
					
							$scope.exhibition_data = result;
							//document.getElementById("exhibition_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updateexhibition=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateExhibition,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					}
				
					else if(event_old.category_id == 5)
					{ 
						jQuery('#modal-5').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_presentation,jsondata);
				
						res.success(function(result){
					
							$scope.presentation_data = result;
							//document.getElementById("presentation_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updatepresentation=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdatePresentation,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					
					}
				
					else if(event_old.category_id == 6)
					{ 
						jQuery('#modal-3').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_tour,jsondata);
				
						res.success(function(result){
					
							$scope.tour_data = result;
							//document.getElementById("tour_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updatetour=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateTour,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					
					}
				
					else if(event_old.category_id == 8)
					{ 
						jQuery('#modal-4').modal('show', {backdrop: 'static'}); 
						
						var jsondata = JSON.stringify({ID : event_old.id});
						var res=$http.post(url_select_event_theatre,jsondata);
				
						res.success(function(result){
					
							$scope.theatre_data = result;
							//document.getElementById("theatre_kind_id").value=result.KIND_ID;
							lat = result.LATITUDE;
							lang = result.LONGITUDE;
						
							setting_map(lang,lat,result.ADDRESS);
							
							$scope.updatetheatre=function(event)
							{		
								event.LATITUDE=lat;
								event.LONGITUDE=lang;
								event.UPDATED_BY=user_id;
												
								res1=$http.post(url_UpdateTheatre,event);
								res1.success(function(result){
							
									if(result==1)
									{
										alert("Event updated");
										$window.location.href = "/index.html"
									}
									else
									{
										alert("Please , Try again");
									}
							
								});
								res1.error(function(result,config,headers,status) { console.log(result); });
							
							};
						
						
					
						});
						res.error(function(result,config,headers,status) { console.log(result); });
					
					}
				
				};
			
				function setting_map(lang_old,lat_old,address){
				
					var markers = [];
        			myCenter=new google.maps.LatLng(lat_old,lang_old);
        			$scope.set_event_update=function(){
			
						google.maps.event.addDomListener(window, 'load', initialize());
            
					};
        
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
						var map=new google.maps.Map(document.getElementById("googleMap_update"),mapProp);
			
			
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
			
						google.maps.event.addListener(map, 'click', function(event) {
							
							DeleteMarkers();
					
							lang_new = event.latLng.lng();
							lat_new = event.latLng.lat();
				
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
					};
		
					function DeleteMarkers() {
		
						for (var i = 0; i < markers.length; i++) {
							markers[i].setMap(null);
						}
						
						markers = [];
					};
	
				};
				
				$scope.save_center = function () {
					
					lang=lang_new;
					lat=lat_new;
				};
		
                            
            }
            else 
            {
                $window.location.href = "/Login.html";
            }
		});
		ress.error(function(status,config,headers,result){});
					 
												
});