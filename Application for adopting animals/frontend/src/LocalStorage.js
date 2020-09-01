const LocalStorageService = (function() {
    var _service;

    function _getService() {
        if (!_service) {
            _service = this;
            return _service
        }
        return _service
    }

    function _setToken(tokenObj) {
        localStorage.setItem('access_token', tokenObj.token);
        localStorage.setItem('role', tokenObj.role);
        localStorage.setItem('userId', tokenObj.userId);
    }

    function _getUserId() {
        return localStorage.getItem('userId')
    }

    function _getAccessToken() {
        return localStorage.getItem('access_token');
    }

    function _getRole() {
        return localStorage.getItem('role');
    }

    function _clearToken() {
        localStorage.removeItem('access_token');
        localStorage.removeItem('role');
    }
    return {
        getService: _getService,
        setToken: _setToken,
        getAccessToken: _getAccessToken,
        getRole: _getRole,
        getUserId: _getUserId,
        clearToken: _clearToken
    }
})();
export default LocalStorageService;