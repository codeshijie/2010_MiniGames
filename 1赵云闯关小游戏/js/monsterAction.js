//怪物控制
$.fn.monsterAction = {};

$.extend($.fn.monsterAction,
      {
          Auto: function(element, gamer) {


              function AutoMove() {

                  if (element.css('display') == 'none') {

                      clearInterval(IntervalMove1); return;
                  }
                  var AbsLength = element.data("Attack").AttackLength;
                  var elementXY = element.offset();
                  var gamerXY = gamer.offset();

                  var x = elementXY.left - gamerXY.left;
                  var y = elementXY.top - gamerXY.top;
                  var r = Math.sqrt(x * x + y * y);

                  if (r > AbsLength) {

                      var Direction = 0;
                      if (Math.abs(y) >= Math.abs(x)) {

                          if (y >= 0) {
                              Direction = 3;
                          } else {
                              Direction = 0;
                          }

                      }
                      else {
                          if (x >= 0)
                          { Direction = 1; }
                          else {
                              Direction = 2;
                          }

                      }

                      if (element.data('Direction') != Direction) {

                          element.data('Direction', Direction);
                          element.data('Animation', 0);
                      }

                      element.monsterAction.ValidJudge(element, Direction);

                  }
                  else {
                      clearInterval(IntervalMove1);
                      IntervalAttack1 = setInterval(AutoAttack, element.data('Walk').WalkFrequency);
                  }





              }
              function AutoAttack() {

                  if (element.css('display') == 'none') {

                      clearInterval(IntervalAttack1); return;
                  }
                  var AbsLength = element.data("Attack").AttackLength;
                  var elementXY = element.offset();
                  var gamerXY = gamer.offset();

                  var x = Math.abs(elementXY.left - gamerXY.left);
                  var y = Math.abs(elementXY.top - gamerXY.top);
                  var r = Math.sqrt(x * x + y * y);
                  if (r > AbsLength) {
                      clearInterval(IntervalAttack1);
                      IntervalMove1 = setInterval(AutoMove, element.data('Walk').WalkFrequency);

                  }
                  else {

                      element.monsterAction.attack(element, gamer);

                  }

              }

              var IntervalMove1 = setInterval(AutoMove, element.data('Walk').WalkFrequency);
              var IntervalAttack1; // setInterval(AutoAttack, element.data('Walk').WalkFrequency);
          },
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
              element.css("z-index", element.offset().top);
              if (x == 3) element.data('Animation', 0)
              else element.data('Animation', x + 1);

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
              element.css("z-index", element.offset().top);
              if (x == 3) element.data('Animation', 0)
              else element.data('Animation', x + 1);

              element.data('WalkKeydownValid', true);


          },
          //行走按键有效仲裁方法
          ValidJudge: function(element, Direction) {

              if (!element.data('AttackKeydownValid')) return;
              if (!element.data('WalkKeydownValid')) return;

              //  element.data('AttackKeydownValid', false);
              element.data('WalkKeydownValid', false);
              if (element.data('Direction') != Direction) {
                  element.data('Direction', Direction);
                  element.data('Animation', 0);
              }


              switch (Direction) {
                  case 1: this.left(element); break;
                  case 2: this.right(element); break;
                  case 3: this.up(element); break;
                  case 0: this.down(element); break;


              }
          },
          //攻击方法
          attack: function(element, gamer) {
              if (!element.data('AttackKeydownValid')) return;
              if (!element.data('WalkKeydownValid')) return;

              element.data('AttackKeydownValid', false);
              element.data('WalkKeydownValid', false);

              var x = 0;
              var y = element.data('Direction');

              var elementXY = element.offset();
              var gamerXY = gamer.offset();
              var x1 = elementXY.left - gamerXY.left;
              var y1 = elementXY.top - gamerXY.top;
              if (Math.abs(y1) >= Math.abs(x1)) {

                  if (y1 >= 0) {
                      y = 3;
                  } else {
                      y = 0;
                  }

              }
              else {
                  if (x1 >= 0)
                  { y = 1; }
                  else {
                      y = 2;
                  }
              }


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

                      clearInterval(AttackIntervalVal);
                      element.attackAlgorithm.bruise(element, gamer);
                      element.data('AttackKeydownValid', true);
                      element.data('WalkKeydownValid', true);
                  }


              }

              var AttackIntervalVal = setInterval(AttackLoop, element.data('Attack').AttackFrequency);

          },
          dead: function(element) {

              element.find('p.walk, p.attack').hide();
              element.find('p.dead').show();
              element.data('AttackKeydownValid', false);
              element.data('WalkKeydownValid', false);
              element.css('z-index', '0');
              if (element.hasClass('NpcCaocao'))
              { alert('打赢了'); location.href = 'game.htm'; }
              else {
                  element.fadeOut(1200, function() { $(this).css('top', -1000) });
              }
          }


      })
