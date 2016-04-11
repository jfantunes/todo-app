define(['backbone','underscore', 'models/model'],
    function (Backbone, _,taskModel) {
        var TaskCollection = Backbone.Collection.extend({
            model: taskModel,
            url: 'Task/Tasks'
        });

        return TaskCollection;

    });

