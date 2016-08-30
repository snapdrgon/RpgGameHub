(function () {
    'use strict';
    var module = angular.module('meetupApp');

    var RpgGameTypeController = function ($scope, rpgGameHub) {
        
        $scope.gameTypeList = function () {
            rpgGameHub.getGameList()
              .then(onList, onError);
        };


        var onError = function (reason) {
            $scope.error = reason;
        };

        var onList = function (response) {
            $scope.gameList = response;
        };

    }

    module.controller("RpgGameTypeController", RpgGameTypeController);

})();