<?php

namespace app\models;

/**
 * This is the ActiveQuery class for [[MailAlias]].
 *
 * @see MailAlias
 */
class MailAliasQuery extends \yii\db\ActiveQuery
{
    /*public function active()
    {
        return $this->andWhere('[[status]]=1');
    }*/

    /**
     * {@inheritdoc}
     * @return MailAlias[]|array
     */
    public function all($db = null)
    {
        return parent::all($db);
    }

    /**
     * {@inheritdoc}
     * @return MailAlias|array|null
     */
    public function one($db = null)
    {
        return parent::one($db);
    }
}
