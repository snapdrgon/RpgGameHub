(function () {
    'use strict';
    var module = angular.module('meetupApp');

    var GameFanController = function ($scope, rpgGameHub) {
        $scope.button;
        var flipFlag;
        $scope.addDeleteAttendance = function ($event, meetId) {

            $scope.button = $event.currentTarget; //grab the object

            flipFlag = ($($scope.button).hasClass("btn-success"));

            if (flipFlag) //remove the attendence
                rpgGameHub.removeAttendence(meetId, $scope.button)
                    .then(onDelete, onError).then(function () { flipButton(); });
            else //add the attendence
                rpgGameHub.addAttendence(meetId, $scope.button)
                    .then(onAdd, onError).then(function () { flipButton(); });
          
            var onDelete = function (response) {
                $scope.delete = response;
            };

            var onAdd = function (response) {
                $scope.add = response
            };

            var flipButton = function () {

                //set the text
                if ($($scope.button).hasClass("btn-success"))
                    $($scope.button).text("Attend?");
                else
                    $($scope.button).text("Attending");

                //flip the class
                $($scope.button).toggleClass("btn-success").toggleClass("btn-default");
            }


        }

       var onError = function (reason) {
            $scope.error = reason;
        };

    }

    module.controller("GameFanController", GameFanController);



})();