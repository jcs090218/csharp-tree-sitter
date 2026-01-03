(defun my-wrap-markup-region ()
  "Insert a markup <b></b> around a region."
  (interactive)
  (let ((p1 (region-beginning)) (p2 (region-end)))
    (goto-char p2)
    (insert "</b>")
    (goto-char p1)
    (insert "<b>")))
