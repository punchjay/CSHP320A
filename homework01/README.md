# CSHP320A

homework01

The uxSubmit button should be disabled unless there is text in both uxName and uxPassword.

As soon as the user enter text in uxName and uxPassword, the uxSubmit button should be enabled.

Hint: Look at all the events for uxName and uxPassword. Maybe they can share a function.

Scenarios to check:

    Both fields empty -> uxSubmit is disabled
    Only one field has text -> uxSubmit is disabled
    Both fields have text -> uxSubmit is enabled
    Both fields have text then you delete both fields -> uxSubmit is disabled