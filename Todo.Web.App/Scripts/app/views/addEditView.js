define(['jquery','backbone', 'underscore','text!templates/formTemplate.html'],
    function ($, Backbone, _,formTemplate) {

        var TasksEditAddView = Backbone.View.extend({

            initialize: function (options) {
                this.operation = options.operation;
            },

            events: {
                "click button.save": "save",
                "click button.cancel": "cancel"
            },

            template: _.template(formTemplate),

            el: $('#taskForm'),

            cancel: function (evt) {
                evt.preventDefault();
                this.remove();
            },

            save: function (evt) {
                evt.preventDefault();

                this.model.set({
                    Description: this.$el.find('input[name=description]').val(),
                    Name: this.$el.find('input[name=name]').val()
                });

                switch (this.operation) {
                    case "Edit":
                        this.model.save();
                        this.remove();
                        break;
                    case "Add":
                        this.addModel();
                        break;
                }

            },

            addModel:function(){
                var that = this;
                this.model.save({}, {
                    success: function () {
                        that.collection.fetch({
                            success: function () {
                                that.remove();
                            },
                            error: function () {
                                that.displayErrorNotification("Couldnt fetch collection");
                            }
                        });

                    }, error: function () {
                        that.displayErrorNotification("Couldnt Add Model");

                    }
                });
             },

            displayErrorNotification: function (message) {
                console.log(message);
            },

            render: function () {
                this.$el.html(this.template(this.model.toJSON()));
                return this;
            },

            remove: function () {
                this.$el.empty().off();
                this.stopListening();
                Backbone.history.navigate("task/index", { trigger: true });
                return this;
            }
        });

        return TasksEditAddView;

    });