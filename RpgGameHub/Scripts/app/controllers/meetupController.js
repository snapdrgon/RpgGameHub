(function () {
    'use strict';
    var module = angular.module('meetupApp');

    var MeetupController = function ($scope, rpgGameHub) {
        $scope.cancelMeetup = function (rpgGameId) {
            $scope.gameId = rpgGameId; //do this so we can pass further down
            bootbox.dialog({
                message: "Are you sure you want to cancel this meetup?",
                title: "Confirm",
                buttons: {
                    no: {
                        label: "No",
                        className: "btn-success",
                        callback: function () {
                         bootbox.hideAll();
                        }
                    },
                    yes: {
                        label: "Yes",
                        className: "btn-danger",
                        callback: function () {
                            rpgGameHub.cancelMeetup($scope.gameId)
                            .then(onCancel, onError);
                        }
                    }
                }
            });
        };

        $scope.getMeetupDetail = function (rpgGameId) {
            rpgGameHub.getMeetupDetail(rpgGameId)
                .then(onDetail, onError);
        };

        var onDetail = function (response) {
            $scope.meetup = response;
        };

         var onCancel = function (response) {
             $scope.cancel = response;
             window.location.reload();
         };

         var onError = function (reason) {
             $scope.error = reason;
         };

    }

    module.controller("MeetupController", MeetupController);



})();