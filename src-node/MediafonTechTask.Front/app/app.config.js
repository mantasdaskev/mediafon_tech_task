'use strict';

angular.
  module('submissionsApp').
  config(['$routeProvider',
    function config($routeProvider) {
      $routeProvider.
        when('/submissions', {
          template: '<submissions-list></submissions-list>'
        }).
        // when('/phones/:phoneId', {
        //   template: '<phone-detail></phone-detail>'
        // }).
        otherwise('/submissions');
    }
  ]);