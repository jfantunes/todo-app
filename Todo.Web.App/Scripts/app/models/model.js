define(['backbone', 'underscore'], function (Backbone, _) {
    var TaskModel = Backbone.Model.extend({

        defaults: {
            Description: 'Insert Description',
            Name: 'Insert Authors Name'

        },
        idAttribute: "Id",

        urlRoot: 'Task/Tasks/'
    });

    return TaskModel;
});