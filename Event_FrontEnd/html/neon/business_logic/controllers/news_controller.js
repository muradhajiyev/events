main_app.controller('news_controller', function($scope, $location, $http, $cookieStore,$cookieStore,$window)
{
    
        
            if($cookieStore.get("token") == undefined)  $window.location.href = "/login.html"
            
            var res = $http.post(url_get_all_news);
            var news = [];
        
            res.success(function(result,config,headers,status) {
                
                for(var i=0;i<result.length;i++)
                                     {
                                        news.push
                                        (
                                           {
                                            id:result[i].ID,
                                            title:result[i].TITLE,
                                            text:result[i].TEXT,
                                            logo_name: result[i].LOGO_NAME,
                                            created_date: result[i].CREATED_DATE
                                           }
                                        )
                                        
                                      }
                                $scope.news = news;
                
            });
            
            res.error(function(result,config,headers,status) {
                console.log(result);
            });      
    
    
            // Pagination variables
            $scope.entryLimit = 5;
            $scope.noOfPages = Math.ceil(news.length / $scope.entryLimit);
            $scope.currentPage = 1;
        
          
});
