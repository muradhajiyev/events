main_app.controller('select_event_controller', function($scope,$http,$rootScope,$cookieStore,$routeParams,$location) {
            

        var id = $routeParams.id;
        var category_id = $routeParams.cat_id;
        var dataObj = { ID : id };
        
    if(category_id == 1)
        {   
                    
                var res = $http.post(url_select_event_sport,dataObj);
                var sport = [];
            
                res.success(function(result,config,headers,status) {
                    
                                            $scope.sport=[

                                                           {

                                                            title:result.TITLE,
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            category: result.CATEGORY,
                                                            kind: result.SPORT_KIND

                                                           }
                                                        ];
					
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);


                    });

                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
            
        }
    else if(category_id == 2)
        {
                
                var res = $http.post(url_select_event_concert,dataObj);
                var concert = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.concert=[

                                                           {
                                                               
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            singer:result.SINGER,
                                                            organizer: result.ORGANIZER,
                                                            title:result.TITLE,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.CONCERT_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
        }
    else if(category_id == 3)
        {
            
                var res = $http.post(url_select_event_seminar,dataObj);
                res.success(function(result,config,headers,status) {
                        
                                            $scope.seminar=[

                                                           {
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            author:result.AUTHOR,
                                                            title:result.TITLE,
                                                            subject:result.SUBJECT,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.SEMINAR_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
        }
    else if(category_id == 4)
        {
            var res = $http.post(url_select_event_exhibition,dataObj);
                var exhibition = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.exhibition=[

                                                           {
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            author:result.AUTHOR,
                                                            title:result.TITLE,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.EXHIBITION_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
        }
    else if(category_id == 5)
        {
                var res = $http.post(url_select_event_presentation,dataObj);
                var presentation = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.presentation=[

                                                           {
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            author:result.AUTHOR,
                                                            title:result.TITLE,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.PRESENTATION_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
        }
    else if(category_id == 6)
        {
                var res = $http.post(url_select_event_tour,dataObj);
                var tour = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.tour=[

                                                           {
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            destination:result.DESTINATION,
                                                            transportation:result.TRANSPORTATION,
                                                            assembling_point:result.ASSEMBLING_POINT,
                                                            organizer:result.ORGANIZER,
                                                            title:result.TITLE,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.TOUR_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
        }
    else if(category_id == 8)
        {
                var res = $http.post(url_select_event_theatre,dataObj);
                var theatre = [];
                res.success(function(result,config,headers,status) {
                        
                                            $scope.theatre=[

                                                           {
                                                            category_id: result.CATEGORY_ID,
                                                            id: result.ID,
                                                            senarist:result.SENARIST,
                                                            producer:result.PRODUCER,
                                                            organizer:result.ORGANIZER,
                                                            title:result.TITLE,
                                                            address:result.ADDRESS,
                                                            description:result.DESCRIPTION,
                                                            price:result.PRICE,
                                                            price_cost: result.PRICE_COST,
                                                            longtitude: result.LONGITUDE,
                                                            latitude: result.LATITUDE,
                                                            start_date: result.START_DATE,
                                                            end_date: result.END_DATE,
                                                            kind_id: result.KIND_ID,
                                                            logo_name: result.LOGO_NAME,
                                                            kind: result.THEATRE_KIND,
                                                            created_by: result.NAME_CREATED_BY,
                                                            category: result.CATEGORY

                                                           }
                                                        ];
					setting_map(result.LONGITUDE,result.LATITUDE,result.ADDRESS);
                }); 
            
                res.error(function(result,config,headers,status) {
                        console.log(result);
                    });
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
            $scope.selectPost = function(id,category_id) {
                $location.path('/editevent/'+id+"/"+category_id);
            }
        
})