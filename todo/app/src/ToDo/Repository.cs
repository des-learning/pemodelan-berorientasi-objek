using System;
using System.Collections.Generic;

namespace ToDo {
    public interface IToDoRepository {
        // Add todo to data store, returns ToDo when success, Nothing when fail 
        Maybe<ToDo> Add(ToDo todo);
        // Update todo by id, returns updated todo when success, nothing when fail
        Maybe<ToDo> Update(int id, ToDo todo);
        // Delete todo by id, returns true when success, false when fail
        bool Delete(int id);
        // Get todo by id, returns todo when success, nothing when fail or not found
        Maybe<ToDo> Get(int id);
        List<ToDo> FindByWaktu(DateTime start, DateTime end);
        List<ToDo> FindByStatus(StatusType status);
        List<ToDo> FindByKeterangan(string keterangan);
    }
}