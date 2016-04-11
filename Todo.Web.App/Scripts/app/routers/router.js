define(['jquery','backbone', 'underscore', 'collections/collection', 'views/addEditView', 'views/indexView','models/model'],
    function ($,Backbone, _ ,TaskCollection,AddEditView,IndexView,TaskModel) {
   
    var TasksRouter = Backbone.Router.extend({
        routes: {
            "task/index": "index",
            "task/delete/:id": "delete",
            "task/edit/:id": "edit",
            "task/create": "create"
        },

        initialize: function () {
            var that = this;
            this.collection = new TaskCollection();
            this.collection.fetch({
                success: function () {
                    Backbone.history.start();
                    that.index();
                },
                error: function () {
                    
                }
            });
        },

        delete: function (id) {
            var task = this.collection.get(id);
            task.destroy();
            Backbone.history.navigate("task/index", { trigger: true });
        },

        edit: function (id) {
            var view = new AddEditView({ model: this.collection.get(id), operation: "Edit" });
            view.render();
        },

        create: function () {
            var view = new AddEditView({ collection: this.collection, model: new TaskModel(), operation: "Add" });
            view.render();
        },

        index: function () {
            var view = new IndexView({ collection: this.collection });
            view.render();
        }

    });

    return TasksRouter;
});