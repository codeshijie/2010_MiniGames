//键盘按键列处理
$.fn.Keyboard = {};
$.extend($.fn.Keyboard,
{
    keydown: function(direction) {
        if (this.alignment.indexOf(direction) == -1) {
            this.alignment += direction;
 
        }

    },
    keyup: function(direction) {

        this.alignment = this.alignment.replace(direction, '');

    },
    alignment: "",
    action: function() {

        var parent = this;
        function actionLoop() {

            if (parent.alignment.length > 0) {

                $("#swordsMan").action.ValidJudge($("#swordsMan"), parseInt(
                            parent.alignment.substring(parent.alignment.length - 1, parent.alignment.length)));

            }
        }
        var v = setInterval(actionLoop, $("#swordsMan").data('Walk').WalkFrequency);

    }



});