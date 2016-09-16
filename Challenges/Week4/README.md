9/16/2016: Week 3's challenge appeared to be a significant challenge, and also raise a series of Git questions.

This week, focus on Treehouse, last weeks challenge, and also try and do a successful merge!  

Some resources provided by our mentors:

From Sunny Gulati, on specifically Git, Visual Studio, and .Net:
https://docs.google.com/document/d/1PekFxJxrKfO83gSwtuTfwJUEsrqouP39_YjPveA21I8/edit#heading=h.1xki1m40vzir

And a more general guide from Shauvon McGill:
http://www.denyconformity.com/post/467/The_Basics_of_Git

And finally some notes from CJ Taylor:

1. `git remote -v`
- If you don't have an "upstream" listed, add one to the code-louisville repo.  `git remote add upstream https://github.com/CodeLouisville/FSJS-Weekly-Challenges.git`

2. `git fetch upstream` - this is similar to refreshing a page in your browser, it's having git go see if there's anything new

3. `git merge upstream/master -m "Merge of weekly challenges"` - this actually gets the changes, then merges them into your current
branch.
- At this point, if you don't include the -m and message, VIM editor will pop up. Remember: `ESC` `:wq` is your ticket out of the VIM editor

4. `git push origin` - this nugget of a command updates YOUR fork on Github so that it's officially part of your repo available online (and not just on your local computer)


Of course, there can be a number of "gotchas" along the way of these steps, if and or when those pop up, PLEASE raise your hand / message / send carrier pigeon / smoke signal for help an we will gladly get your moving along!
