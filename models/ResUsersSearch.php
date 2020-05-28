<?php

namespace app\models;

use yii\base\Model;
use yii\data\ActiveDataProvider;
use app\models\ResUsers;

class ResUsersSearch extends ResUsers
{
    public function rules()
    {
        return [
            [['id', 'active', 'company_id', 'partner_id', 'action_id', 'share', 'create_uid', 'write_uid', 'alias_id', 'website_id', 'sale_team_id', 'target_sales_won', 'target_sales_done', 'target_sales_invoiced', 'karma', 'rank_id', 'next_rank_id'], 'integer'],
            [['login', 'password', 'create_date', 'signature', 'write_date', 'notification_type', 'out_of_office_message', 'odoobot_state', 'livechat_username', 'trial532'], 'safe'],
        ];
    }

    public function scenarios()
    {
        return Model::scenarios();
    }

    public function search($params)
    {
        $query = ResUsers::find();


        $dataProvider = new ActiveDataProvider([
            'query' => $query,
        ]);

        $this->load($params);

        if (!$this->validate()) {
            return $dataProvider;
        }

        $query->andFilterWhere([
            'id' => $this->id,
            'active' => $this->active,
            'company_id' => $this->company_id,
            'partner_id' => $this->partner_id,
            'create_date' => $this->create_date,
            'action_id' => $this->action_id,
            'share' => $this->share,
            'create_uid' => $this->create_uid,
            'write_uid' => $this->write_uid,
            'write_date' => $this->write_date,
            'alias_id' => $this->alias_id,
            'website_id' => $this->website_id,
            'sale_team_id' => $this->sale_team_id,
            'target_sales_won' => $this->target_sales_won,
            'target_sales_done' => $this->target_sales_done,
            'target_sales_invoiced' => $this->target_sales_invoiced,
            'karma' => $this->karma,
            'rank_id' => $this->rank_id,
            'next_rank_id' => $this->next_rank_id,
        ]);

        $query->andFilterWhere(['like', 'login', $this->login])
            ->andFilterWhere(['like', 'password', $this->password])
            ->andFilterWhere(['like', 'signature', $this->signature])
            ->andFilterWhere(['like', 'notification_type', $this->notification_type])
            ->andFilterWhere(['like', 'out_of_office_message', $this->out_of_office_message])
            ->andFilterWhere(['like', 'odoobot_state', $this->odoobot_state])
            ->andFilterWhere(['like', 'livechat_username', $this->livechat_username])
            ->andFilterWhere(['like', 'trial532', $this->trial532]);

        return $dataProvider;
    }
}
