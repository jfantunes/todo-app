define(['jquery', 'backbone', 'underscore', 'text!templates/listTemplate.html'],
    function ($, Backbone, _,renderListTemplate) {

        var TasksIndexView = Backbone.View.extend({

            template: _.template(renderListTemplate),

            el: $('#taskListContainer'),

            render: function () {
                this.$el.html(
                    this.template({ tasks: this.collection.toJSON() })
                );
                return this;
            }
        });

        return TasksIndexView;
    });