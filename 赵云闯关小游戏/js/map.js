$.fn.map = {};
$.extend($.fn.map,
        {
            mapLeft: 340,
            mapRight: 610,
            mapTop: 500,
            mapDown: 4940,
            mapMove: function(element) {

                var v1 = element.offset().top - $(window).height() / 2;
                var v2 = $(document).scrollTop();



                if (v1 > v2 && Math.abs(v1 - v2) > 50) {
                    if (Math.abs(v1 - v2) > 200) {
                        $(document).scrollTop(v2 + 10);
                    } else
                    { $(document).scrollTop(++v2); }
                }
                else if (v1 < v2 && Math.abs(v1 - v2) > 50) {
                    if (Math.abs(v1 - v2) > 200) {
                        $(document).scrollTop(v2 - 10);
                    } else {
                        $(document).scrollTop(--v2);
                    }
                }


            },
            Npc: { Create: function(gamer) {

                var Npc1 = this;
                function NpcCreat() {

                    for (i = 0; i <= 10; i++) {
                        var type = 'NpcCaocao';

                        switch (Npc1.num) {
                            case 4: type = "NpcMutou"; break;
                            case 3: type = "NpcQingbubing"; break;
                            case 2: type = "NpcSunshangxiang"; break;
                            case 1: type = "NpcCaocao"; i = 5; break;


                        }
                        if (i == 5) {
                            switch (Npc1.num) {
                                case 4: type = "NpcXiahoudun"; break;
                                case 3: type = "NpcZhanghe"; break;
                                case 2: type = "NpcPangde"; break;
                                case 1: type = "NpcCaocao"; break;
                            }

                        }


                        var v = $(Npc1.model.replace(/###/, type));

                        v.appendTo('body').data(eval(type + 'Data')).css({ 'top': gamer.offset().top - ((i == 5) ? 400 : 350), 'left': 380 + i * 30 }).monsterAction.Auto(v, $("#swordsMan"));

                        if (Npc1.num == 1) {

                            clearInterval(IntervalCreatNpc);
                            break;
                        }
                    }
                    Npc1.num--;

                }

                var IntervalCreatNpc = setInterval(NpcCreat, 10000);
                if (this.num == 4) {
                    NpcCreat();
                }
            },
                model: "    <div class='###  Npc'>\
                    <p class='walk'>\
                    </p>\
                     <p class='attack'>\
            </p>\
            <p class='dead'>\
            </p>\
        </div>",
                num: 4
            }
        });

 