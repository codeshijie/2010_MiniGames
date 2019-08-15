//gamer控制
$.fn.action = {};


$.extend($.fn.action,
        {
            left: function(element) {

                if (element.offset().left < $(document).map.mapLeft) {

                    element.data('WalkKeydownValid', true);
                    return;
                }
                element.find('p.attack, p.dead').hide();
                element.find('p.walk').show();
                var x = element.data('Animation');
                var y = element.data('Direction');
                var point = element.data('Walk').PositionList[y][x];

                element.animate(
                                                                {
                                                                    left: "-=" + element.data('width')
                                                                },
                                                                {
                                                                    easing: "linear",
                                                                    duration: element.data('Walk').WalkFrequency

                                                                }
                                                              );
                element.find('p.walk').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"
                                                }
                                                );
                if (x == 3) element.data('Animation', 0)
                else element.data('Animation', x + 1);

                element.data('WalkKeydownValid', true);


            },
            right: function(element) {


                if (element.offset().left > $(document).map.mapRight) {

                    element.data('WalkKeydownValid', true);
                    return;
                }

                element.find('p.attack, p.dead').hide();
                element.find('p.walk').show();
                var x = element.data('Animation');
                var y = element.data('Direction');
                var point = element.data('Walk').PositionList[y][x];

                element.animate(
                                                                {
                                                                    left: "+=" + element.data('width')
                                                                },
                                                                {
                                                                    easing: "linear",
                                                                    duration: element.data('Walk').WalkFrequency

                                                                }
                                                              );
                element.find('p.walk').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"

                                                }
                                                );

                if (x == 3) element.data('Animation', 0)
                else element.data('Animation', x + 1);

                element.data('WalkKeydownValid', true);


            },
            up: function(element) {


                if (element.offset().top < $(document).map.mapTop) {

                    element.data('WalkKeydownValid', true);
                    return;
                }
                element.find('p.attack, p.dead').hide();
                element.find('p.walk').show();
                var x = element.data('Animation');
                var y = element.data('Direction');
                var point = element.data('Walk').PositionList[y][x];

                element.animate(
                                                                {
                                                                    top: "-=" + element.data('height')
                                                                },
                                                                {
                                                                    easing: "linear",
                                                                    duration: element.data('Walk').WalkFrequency

                                                                }
                                                              );
                element.find('p.walk').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"
                                                }
                                                );

                if (x == 3) element.data('Animation', 0)
                else element.data('Animation', x + 1);
                element.css("z-index", element.offset().top);
                element.data('WalkKeydownValid', true);




            },
            down: function(element) {


                if (element.offset().top > $(document).map.mapDown) {
                    element.data('WalkKeydownValid', true);
                    return;
                }
                element.find('p.attack, p.dead').hide();
                element.find('p.walk').show();
                var x = element.data('Animation');
                var y = element.data('Direction');
                var point = element.data('Walk').PositionList[y][x];

                element.animate(
                                                                {
                                                                    top: "+=" + element.data('height')
                                                                },
                                                                {
                                                                    easing: "linear",
                                                                    duration: element.data('Walk').WalkFrequency

                                                                }
                                                              );
                element.find('p.walk').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"
                                                }
                                                );

                if (x == 3) element.data('Animation', 0)
                else element.data('Animation', x + 1);
                element.css("z-index", element.offset().top);
                element.data('WalkKeydownValid', true);


            },
            //行走按键有效仲裁方法
            ValidJudge: function(element, Direction) {

                if (!element.data('AttackKeydownValid')) return;
                if (!element.data('WalkKeydownValid')) return;

                //   element.data('AttackKeydownValid', false);
                element.data('WalkKeydownValid', false);
                if (element.data('Direction') != Direction) {
                    element.data('Direction', Direction);
                    element.data('Animation', 0);
                }



                element.stop(true, true);
                switch (Direction) {
                    case 1: this.left(element); break;
                    case 2: this.right(element); break;
                    case 3: this.up(element); break;
                    case 0: this.down(element); break;


                }


            },
            //攻击方法
            attack: function(element) {

                if (!element.data('AttackKeydownValid')) return;


                element.data('AttackKeydownValid', false);
                element.data('WalkKeydownValid', false);

                var x = 0;
                var y = element.data('Direction');

                function AttackLoop() {

                    element.find('p.walk, p.dead').hide();
                    element.find('p.attack').show();
                    var point = element.data('Attack').PositionList[y][x];


                    element.find('p.attack').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"
                                                }
                                                );

                    x++;

                    if (x == 4) {

                        clearInterval(attackIntervalVal);
                        element.find('p.attack, p.dead').hide();
                        element.find('p.walk').show();
                        element.attackAlgorithm.attack($('.Npc'), element);
                        element.data('AttackKeydownValid', true);
                        element.data('WalkKeydownValid', true);
                    }
                }

                var attackIntervalVal = setInterval(AttackLoop, element.data('Attack').AttackFrequency);

            },
            //攻击方法
            attackMagic: function(element) {

                if (!element.data('AttackKeydownValid')) return;


                if (element.data('Magic') <= 0) {
                    return;
                }
                else {
                    element.data('Magic', element.data('Magic') - 10);
                    $(".magic span").css("height", element.data("Magic") / 4);
                }

                element.data('AttackKeydownValid', false);
                element.data('WalkKeydownValid', false);


                function AttackLoop() {

                    var x = 2;
                    var y = element.data('Direction');

                    var oldoffset = element.offset();
                    var point = element.data('Attack').PositionList[y][x];



                    element.find('p.attack').css(
                                                {

                                                    "background-position": point[0] + "px " + point[1] + "px"
                                                }
                                                );
                    var v1, v2;


                    var length = element.data('Attack').AttackMagicLength;
                    switch (element.data('Direction')) {
                        case 1:

                            if (element.offset().left - element.data('Attack').AttackMagicLength < $(document).map.mapLeft) {
                                length = element.offset().left - $(document).map.mapLeft;
                            }
                            v1 = "+=0"; v2 = "-=" + length; break;
                        case 2:
                            if (element.offset().left + element.data('Attack').AttackMagicLength > $(document).map.mapRight) {
                                length = element.data('Attack').AttackMagicLength -
                                 (element.data('Attack').AttackMagicLength + element.offset().left - $(document).map.mapRight);
                            }
                            v1 = "+=0"; v2 = "+=" + length; break;
                        case 3:
                            if (element.offset().top - element.data('Attack').AttackMagicLength < $(document).map.mapTop) {
                                length = element.data('Attack').AttackMagicLength -
                                 ($(document).map.mapTop - (element.offset().top - element.data('Attack').AttackMagicLength));
                            }
                            v1 = "-=" + length; v2 = "-=0"; break;
                        case 0:

                            if (element.offset().top + element.data('Attack').AttackMagicLength > $(document).map.mapDown) {

                                length = element.data('Attack').AttackMagicLength - (
                                (element.offset().top + element.data('Attack').AttackMagicLength) - $(document).map.mapDown);
                            }
                            v1 = "+=" + length; v2 = "+=0"; break;
                    }
                    element.find('p.walk, p.dead').hide();
                    element.find('p.attack').show();
                    element.animate(
                                                                {
                                                                    top: v1,
                                                                    left: v2

                                                                },
                                                                {
                                                                    easing: "linear",
                                                                    duration: element.data('Attack').AttackMagicFrequency,
                                                                    complete: function() {

                                                                        x = 0;
                                                                        point = element.data('Walk').PositionList[y][x];
                                                                        element.find('p.Walk').css(
                                                                        {

                                                                            "background-position": point[0] + "px " + point[1] + "px"
                                                                        }
                                                                        );
                                                                        element.find('p.attack, p.dead').hide();
                                                                        element.find('p.walk').show();
                                                                        element.attackAlgorithm.Magicattack($('.Npc'), element, oldoffset);
                                                                        element.data('AttackKeydownValid', true);
                                                                        element.data('WalkKeydownValid', true);
                                                                    }
                                                                }
                                                              );


                }

                AttackLoop();

            },
            dead: function(element) {
                element.find('p.walk, p.attack').hide();
                element.find('p.dead').show();
                element.data('AttackKeydownValid', false);
                element.data('WalkKeydownValid', false);
                element.css('z-index', '-=500');
                element.fadeOut(1000, function() { alert('挂掉了'); location.href = 'game.htm'; });
            }
        })


