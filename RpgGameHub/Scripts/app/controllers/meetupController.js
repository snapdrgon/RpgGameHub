(function () {
    'use strict';

    function MeetupController($scope, $http) {

       $scope.cancelMeetup = function (rpgGameId) {
           var url = '/api/meetup/' + rpgGameId;
            return $http.delete(url)
                .then(function (response) {
                    return response.data;
                });
        };
    }

    angular
     .module('meetupApp')
     .controller('MeetupController', MeetupController);



})();