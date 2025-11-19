import { Grid } from "@mui/material";
import ActivityList from "../dashboard/ActivityList";
import ActivityForm from "../form/ActivityForm";
import ActivityDetail from "../details/ActivityDetail";
export default function ActivityDashboard() {

    return (
        <Grid container spacing={3}>
            <Grid size={7}>
                <ActivityList />
            </Grid>
            <Grid size={5}>
                Activity Filters go here
            </Grid>
        </Grid>
    )
}
