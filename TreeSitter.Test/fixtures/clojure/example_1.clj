;; A list
'(1 2 3 4)
;; => (1 2 3 4)

;; A vector (more common for general-purpose collections)
[1 2 3 4]
;; => [1 2 3 4]

;; A map (hash map)
(def person {:first "Han" :last "Solo" :occupation "smuggler"})
;; => #'user/person

;; Accessing a value in a map (keywords can act as functions)
(:first person)
;; => "Han"

;; Using a function with a collection
(map inc [1 2 3]) ; inc increments by 1
;; => (2 3 4)

;; Using the 'thread-first' macro to make code more readable
(-> person :occupation count)
;; is equivalent to: (count (:occupation person))
;; => 8
