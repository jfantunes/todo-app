require.config({
    paths: {
        "jquery": "../libs/jquery-1.8.2",
        "underscore": "../libs/underscore",
        "backbone": "../libs/backbone",
        "text": "../libs/text"
    },
    shim: {
        'backbone': {
            deps: ['underscore']
        }
    }
    
});

require(['routers/router'], function (TaskRouter) {
    new TaskRouter();
   
});