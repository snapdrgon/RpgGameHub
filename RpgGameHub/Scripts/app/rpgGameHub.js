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

        var addAttendence = function (meetId, button) {
            var url = '/api/gamefan/' + meetId;
            return $http.post(url)
            .then(function (response) {
                return response.data;
            });
        }
        var removeAttendence = function (meetId, button) {
            var url = '/api/gamefan/' + meetId;
            return $http.delete(url)
            .then(function (response) {
                return response.data;
            });
        }

 
        return {
            cancelMeetup: cancelMeetup,
            getMeetupDetail: getMeetupDetail,
            addAttendence:addAttendence,
            removeAttendence:removeAttendence
        };
    };
    var module = angular.module("meetupApp");
    module.factory("rpgGameHub", rpgGameHub);

}());