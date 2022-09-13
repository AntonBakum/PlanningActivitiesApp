import React from "react";
import { Grid, GridColumn, List } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";
import ActivitiesList from "./ActivitiesList";
interface Props
{
    activities: Activity [];
}
export default function ActivityDashboard({activities}: Props )
{
    return (
        <Grid>
            <Grid.Column width= "10">
                <ActivitiesList activities={activities}/>
            </Grid.Column>
        </Grid>
    )
}