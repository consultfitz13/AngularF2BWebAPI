(function () {
    "use strict";

    angular
        .module("common.services")
        .factory("currentUser", currentUser)

    function currentUser() {
        var profile = {
            isLoggedIn: false,
            userName: "",
            token: ""
        };

        var setProfile = function(userName, token) {
            profile.userName = userName;
            profile.token = token;
            profile.isLoggedIn = true;
        };

        var getProfile = function() {
            return profile;
        };

        return {
            setProfile: setProfile,
            getProfile: getProfile
        }

    }

}());