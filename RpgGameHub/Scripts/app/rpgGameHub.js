(function(){
  
    var rpgGameHub = function($http){
    
        var cancelMeetup = function (rpgGameId) {
            alert('taz');
            var url = "'/api/meetup/' + rpgGameId";
            return $http.delete(url)
                .then(function(response)
                {
                    return response.data;
                });
        };
        return {
            cancelMeetup: cancelMeetup
        };
    };
    var module = angular.module("meetupApp");
    module.factory("rpgGameHub", rpgGameHub);

}());