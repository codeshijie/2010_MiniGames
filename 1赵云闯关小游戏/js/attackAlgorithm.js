//攻击算法
$.fn.attackAlgorithm = {};


$.extend($.fn.attackAlgorithm,
        {
            attack: function(element, gamer) {
                var AbsLength = gamer.data("Attack").AttackLength;

                $(element).each(function() {
                    var element1 = $(this);
                    var x = element1.offset().left - gamer.offset().left;
                    var y = element1.offset().top - gamer.offset().top;
                    var r = Math.sqrt(x * x + y * y);


                    if (AbsLength >= r) {

                        element1.data("Blood", element1.data("Blood") - gamer.data("Attack").Lethality);
                        if (element1.data("Blood") <= 0) {

                            element1.monsterAction.dead(element1);
                        }

                    }
                });

            },
            Magicattack: function(element, gamer, oldoffset) {
                var AbsLength = gamer.data("Attack").AttackLength;
                var newoffset = gamer.offset();
                $(element).each(function() {

                    var element1 = $(this);
                    var offset1 = element1.offset();
                    var x = (Math.min(newoffset.left, oldoffset.left) - AbsLength) <= offset1.left
                                &&
                                (Math.max(newoffset.left, oldoffset.left) + AbsLength) >= offset1.left
                                 ;
                    var y = (Math.min(newoffset.top, oldoffset.top) - AbsLength) <= offset1.top
                                &&
                                (Math.max(newoffset.top, oldoffset.top) + AbsLength) >= offset1.top
                                 ;


                    if (x && y) {

                        element1.data("Blood", element1.data("Blood") - gamer.data("Attack").AttackMagicLethality);
                        if (element1.data("Blood") <= 0) {

                            element1.monsterAction.dead(element1);
                        }

                    }
                });

            },
            bruise: function(element, gamer) {

                if (gamer.data("Blood") <= 0) { return; }
                var AbsLength = element.data("Attack").AttackLength;

                var x = $(element).offset().left - gamer.offset().left;
                var y = $(element).offset().top - gamer.offset().top;
                var r = Math.sqrt(x * x + y * y);

                if (AbsLength >= r) {

                    gamer.data("Blood", gamer.data("Blood") - element.data("Attack").Lethality);
                    $(".blood span").css("height", gamer.data("Blood") / 4);

                    if (gamer.data("Blood") <= 0) {

                        gamer.action.dead(gamer);

                    }
                }
            }




        });

 