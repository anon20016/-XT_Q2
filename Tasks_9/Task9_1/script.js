$(document).ready(function () {
    document.getElementById("go").addEventListener('click',
        function (e) {
            var str = document.getElementById("text").value;
            var separator = ["?", "!", ":", ";", ",", ".", " ", "\t"];
            var arr = str.split(''),
                letters = [],
                cnt = 0,
                words = [];

            arr.forEach(function (letter, i) {
                if (separator.indexOf(letter) != -1) {
                    words.push(str.substr(cnt, i - cnt));
                    cnt = i + 1;
                }
            });

            words.push(str.substr(cnt));

            for (var i = 0; i < words.length; i++) {
                var word = words[i];

                for (var j = 0; j < word.length; j++) {
                    for (var q = j + 1; q < word.length; q++) {
                        if (word[j] === word[q])
                            letters.push(word[j]);
                    }
                }
            }

            for (var i = 0; i < letters.length; i++) {
                while (str !== str.replace(letters[i], '')) {
                    str = str.replace(letters[i], '');
                }
            }

            document.getElementById("result").value = str;
        });
});
