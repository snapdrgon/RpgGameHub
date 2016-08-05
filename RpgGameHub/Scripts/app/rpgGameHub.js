(function(){
  
    var rpgGameHub = function($http){
    
        var cancelMeetup = function (rpgGameId) {
            var url = '/api/meetup/' + rpgGameId;
            return $http.delete(url)
                .then(function(response)
                {
                    return response.data;
                });
        };

        var getMeetupDetail = function (rpgGameId) {
            var url = '/api/meetup/' + rpgGameId;
            return $http.get(url)
            .then(function (response) {
                return response.data;
            });
        }
        return {
            cancelMeetup: cancelMeetup,
            getMeetupDetail: getMeetupDetail
        };
    };
    var module = angular.module("meetupApp");
    module.factory("rpgGameHub", rpgGameHub);

}());